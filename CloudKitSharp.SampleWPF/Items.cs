using CloudKitSharp.Core.Http;
using System.Text.Json.Serialization;

namespace CloudKitSharp.SampleWPF
{
    public class Items
    {
        [JsonPropertyName("count"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public CKValue<int>? count { get; set; }
        [JsonPropertyName("price"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public CKValue<int>? price { get; set; }
        [JsonPropertyName("name"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public CKValue<string>? name { get; set; }
    }
}
