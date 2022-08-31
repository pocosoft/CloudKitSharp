using CloudKitSharp.Core.Model;
using RestSharp;
using System.Text.Json.Serialization;

namespace CloudKitSharp.Core.Http
{
    public class RecordsQueryResponse<T>
    {
        [JsonPropertyName("records")]
        public List<RecordDictionary<T>>? records { get; set; }
    }
}
