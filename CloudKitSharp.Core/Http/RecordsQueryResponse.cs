using CloudKitSharp.Core.Model;
using RestSharp;
using System.Text.Json.Serialization;

namespace CloudKitSharp.Core.Http
{
    public class RecordsQueryResponse
    {
        [JsonPropertyName("records")]
        public List<RecordDictionary>? records { get; set; }
    }

    public class RecordsQueryResponse<T>
    {
        [JsonPropertyName("records")]
        public List<RecordDictionary<T>>? records { get; set; }
    }
}
