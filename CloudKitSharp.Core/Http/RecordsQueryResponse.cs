using CloudKitSharp.Core.Model;
using RestSharp;
using System.Text.Json.Serialization;

namespace CloudKitSharp.Core.Http
{
    public class RecordsQueryResponse
    {
        [JsonPropertyName("records")]
        public RecordDictionary[]? records { get; set; }
    }
}
