using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

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
