using EllipticCurve;
using Newtonsoft.Json;
using RestSharp;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

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
        /// <summary>
        /// Fetching Current User Identity (users/caller)
        /// https://developer.apple.com/library/archive/documentation/DataManagement/Conceptual/CloudKitWebServicesReference/FetchCurrentUserIdentity.html#//apple_ref/doc/uid/TP40015240-CH27-SW1
        /// </summary>
        /// <param name="webAuthToken"></param>
        /// <returns></returns>
        public async Task<RestResponse<UsersCallerResponse>> GetUsersCaller(string webAuthToken)
        {
            var request = new UsersCallerRequest();
            return await Fetch<UsersCallerResponse>(request, webAuthToken);
        }
        /// <summary>
        /// Discovering All User Identities (GET users/discover)
        /// https://developer.apple.com/library/archive/documentation/DataManagement/Conceptual/CloudKitWebServicesReference/DiscoveringAllUserIdentities.html#//apple_ref/doc/uid/TP40015240-CH31-SW1
        /// </summary>
        /// <param name="webAuthToken"></param>
        /// <returns></returns>
        public async Task<RestResponse<UsersCallerResponse>> GetUsersDiscover(string webAuthToken)
        {
            var request = new UserDiscoverRequest();
            return await Fetch<UsersCallerResponse>(request, webAuthToken);
        }
        /// <summary>
        /// Fetching Records Using a Query (records/query)
        /// https://developer.apple.com/library/archive/documentation/DataManagement/Conceptual/CloudKitWebServicesReference/QueryingRecords.html#//apple_ref/doc/uid/TP40015240-CH5-SW4
        /// </summary>
        /// <param name="database"></param>
        /// <param name="webAuthToken"></param>
        /// <returns></returns>
        public async Task<RestResponse<RecordsQueryResponse>> PostRecordsQuery(CKDatabase database, RecordsQueryRequest.Parameter parameter, string webAuthToken)
        {
            var request = new RecordsQueryRequest(database, parameter);
            return await Fetch<RecordsQueryResponse>(request, webAuthToken);
        }
        public async Task<RestResponse<T>> Fetch<T>(ICKRequest request, string webAuthToken)
        {
            switch (request.Method)
            {
                case Method.Get:
                    return await Get<T>(request, webAuthToken);
                case Method.Post:
                    return await Post<T>(request, webAuthToken);
                default:
                    throw new Exception();
            }
        }
        async Task<RestResponse<T>> Get<T>(ICKRequest request, string webAuthToken)
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
        async Task<RestResponse<T>> Post<T>(ICKRequest request, string webAuthToken)
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

        string MakeDateByISO8601(DateTime datetime)
        {
            return datetime.ToString("yyyy-MM-dd'T'HH:mm:ss'Z'");
        }
        string MakeMessage(ICKRequest request, DateTime datetime)
        {
            var body = MakeRequestBodyString(request);
            return MakeDateByISO8601(datetime) + ":" + Base64EncodedBodyString(body) + ":" + request.Path(_container);
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
        private static readonly SHA256 HashProvider = SHA256.Create();
    }
}
