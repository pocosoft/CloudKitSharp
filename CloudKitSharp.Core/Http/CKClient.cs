using EllipticCurve;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CloudKitSharp.Core.Http
{
    public class CKClient
    {
        private static readonly RestClient _restClient = new RestClient();
        private const string CKAPITokenKey = "ckAPIToken";
        private const string CKWebAuthTokenKey = "ckWebAuthToken";
        private const string CKRequestKeyIDKey = "X-Apple-CloudKit-Request-KeyID";
        private const string RequestISO8601DateKey = "X-Apple-CloudKit-Request-ISO8601Date";
        private const string RequestSignatureV1Key = "X-Apple-CloudKit-Request-SignatureV1";
        private readonly string _container;
        private readonly string _apiToken;
        private readonly string _requestKeyID;
        private readonly string _privateKeyString;
        public CKClient(
            string container,
            string apiToken,
            string requestKeyID,
            string privateKeyString
            )
        {
            _container = container;
            _apiToken = apiToken;
            _requestKeyID = requestKeyID;
            _privateKeyString = privateKeyString;
        }

        public async Task<RestResponse<UsersCallerResponse>> GetUsersCaller(string? webAuthToken)
        {
            var request = new UsersCallerRequest();
            return await Get<UsersCallerResponse>(request, webAuthToken);
        }
        public async Task<RestResponse<T>> Get<T>(ICKRequest request, string? webAuthToken)
        {
            var url = request.GetUrl(_container);
            Debug.Print(url);
            var restRequest = new RestRequest(url, Method.Get);
            restRequest.AddQueryParameter(CKAPITokenKey, _apiToken);
            if (webAuthToken != null)
            {
                restRequest.AddQueryParameter(CKWebAuthTokenKey, webAuthToken);
            }
            return await _restClient.ExecuteAsync<T>(restRequest);
        }
        public async Task<RestResponse<T>> Post<T>(ICKRequest request, string webAuthToken)
        {
            var restRequest = new RestRequest(request.GetUrl(_container), Method.Post);
            Debug.Print("Request" + restRequest.ToString());
            restRequest.AddQueryParameter(CKAPITokenKey, _apiToken);
            restRequest.AddQueryParameter(CKWebAuthTokenKey, webAuthToken);
            var dateTime = DateTime.UtcNow;
            var message = MakeMessage(request, dateTime);
            Debug.WriteLine(message);
            var signature = MakeSignature(message);
            Debug.WriteLine(signature);
            restRequest.AddHeader(CKRequestKeyIDKey, _requestKeyID);
            restRequest.AddHeader(RequestISO8601DateKey, MakeDateByISO8601(dateTime));
            restRequest.AddHeader(RequestSignatureV1Key, signature);
            if (request.Body != null)
            {
                restRequest.AddJsonBody(request.Body, "application/json");
            }
            Debug.Print(JsonConvert.SerializeObject(request.Body));
            return await _restClient.ExecuteAsync<T>(restRequest);
        }

        public string MakeDateByISO8601(DateTime datetime)
        {
            return datetime.ToString("yyyy-MM-dd'T'HH:mm:ss'Z'");
        }
        public string MakeMessage(ICKRequest request, DateTime datetime)
        {
            var body = MakeRequestBodyString(request);
            return MakeDateByISO8601(datetime) + ":" + Base64EncodedBodyString(body) + ":" + request.SubPath;
        }
        string MakeRequestBodyString(object requestBody)
        {
            return JsonConvert.SerializeObject(requestBody);
        }
        string Base64EncodedBodyString(string body)
        {
            var bytes = Encoding.UTF8.GetBytes(body);
            var hashed = HashProvider.ComputeHash(bytes);
            return Convert.ToBase64String(hashed);
        }
        string MakeSignature(string message)
        {
            PrivateKey privateKey = PrivateKey.fromPem(_privateKeyString);
            Signature signature = Ecdsa.sign(message, privateKey);
            var publicKey = privateKey.publicKey();
            var verify = Ecdsa.verify(message, signature, publicKey);
            if (verify)
            {
                return signature.toBase64();
            }
            else
            {
                throw new Exception("著名失敗");
            }
        }
        static readonly SHA256 HashProvider = SHA256.Create();
    }
}
