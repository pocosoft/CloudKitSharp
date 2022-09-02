using RestSharp;
using System.Net;
using System.Text.Json;

namespace CloudKitSharp.Core.Http
{
    public class CKResponse<Success, Failure>
    {
        public Success? Data;
        public Failure? Error;
        public HttpStatusCode StatusCode;
        public bool IsSuccessful;
        public string? Content;
        public CKResponse(RestResponse<Success> restResponse)
        {
            StatusCode = restResponse.StatusCode;
            IsSuccessful = restResponse.IsSuccessful;
            Content = restResponse.Content;
            Data = restResponse.Data;
            if (!IsSuccessful && Content != null)
            {
                Error = JsonSerializer.Deserialize<Failure>(Content);
            }
        }
    }
}
