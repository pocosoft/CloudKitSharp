using EllipticCurve;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
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
        private const string API_TOKEN_KEY = "ckAPIToken";
        private const string WEB_AUTH_TOKEN_KEY = "ckWebAuthToken";
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _container;
        private readonly string _environment;
        private readonly string _database;
        private readonly string _apiToken;
        private readonly string _privateKeyString = "";
        public CKClient(
            IHttpClientFactory httpClientFactory, 
            string container,
            string environment,
            string database,
            string apiToken)
        {
            _httpClientFactory = httpClientFactory;
            _container = container;
            _environment = environment; 
            _database = database;
            _apiToken = apiToken;
        }

        public async Task GetUser()
        {
            var httpRequestMessage = new HttpRequestMessage(
            HttpMethod.Get,
            "https://api.github.com/repos/dotnet/AspNetCore.Docs/branches")
            {
                Headers =
            {
                { HeaderNames.Accept, "application/vnd.github.v3+json" },
                { HeaderNames.UserAgent, "HttpRequestsSample" }
            }
            };

            var httpClient = _httpClientFactory.CreateClient();
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();

                // GitHubBranches = await JsonSerializer.DeserializeAsync<IEnumerable<GitHubBranch>>(contentStream);
            }
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
            return JsonSerializer.Serialize(requestBody);
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
