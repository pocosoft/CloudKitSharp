using CloudKitSharp.Core.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace CloudKitSharp.SampleWPF
{
    public class Items
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public CKValue<int>? count { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public CKValue<int>? price { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public CKValue<string>? name { get; set; }
    }
}
