using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace CloudKitSharp.Core.Http
{
    public struct CKError
    {
        public string Uuid { get; set; }
        public string ServerErrorCode { get; set; }
        public string Reason { get; set; }
        public string RedirectURL? { get; set; }

        public static CKError Parse(string jsonString)
        {
            var serializeOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            return JsonSerializer.Deserialize<CKError>(jsonString, serializeOptions);
        }
    }
}
