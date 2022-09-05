using CloudKitSharp.Core.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CloudKitSharp.Core.Tests.Http
{
    public class RecordsModifyResponseTest
    {
        [Fact]
        public void JsonParseTest()
        {
            var result = JsonSerializer.Deserialize<RecordsModifyResponse<Items>>(jsonString);
            Assert.NotNull(result);
            Assert.Equal(1, result?.records?.Count);
            var firstItem = result?.records?.First();
            Assert.NotNull(firstItem);
            Assert.Equal("13C3B69E-A0E7-85CA-266C-767D1E58D891", firstItem?.recordName);
            Assert.Equal(200, firstItem?.fields?.price?.value);
            Assert.Equal(11, firstItem?.fields?.count?.value);
            Assert.Equal("Strawberry", firstItem?.fields?.name?.value);
            Assert.Equal("_d8e2b6c17258c644a282008756152412", firstItem?.modified?.userRecordName);
            Assert.Equal(1662388216238, firstItem?.modified?.timestamp);
        }

        public class Items
        {
            [JsonPropertyName("count"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
            public CKValue<int>? count { get; set; }
            [JsonPropertyName("price"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
            public CKValue<int>? price { get; set; }
            [JsonPropertyName("name"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
            public CKValue<string>? name { get; set; }
        }

        private string jsonString = @"
{
  ""records"" : [ {
    ""recordName"" : ""13C3B69E-A0E7-85CA-266C-767D1E58D891"",
    ""recordType"" : ""Items"",
    ""fields"" : {
      ""price"" : {
        ""value"" : 200,
        ""type"" : ""INT64""
      },
      ""count"" : {
        ""value"" : 11,
        ""type"" : ""INT64""
      },
      ""name"" : {
        ""value"" : ""Strawberry"",
        ""type"" : ""STRING""
      }
    },
    ""pluginFields"" : { },
    ""recordChangeTag"" : ""l76z3p93"",
    ""created"" : {
      ""timestamp"" : 1661306678709,
      ""userRecordName"" : ""_d8e2b6c17258c644a282008756152412"",
      ""deviceID"" : ""2""
    },
    ""modified"" : {
      ""timestamp"" : 1662388216238,
      ""userRecordName"" : ""_d8e2b6c17258c644a282008756152412"",
      ""deviceID"" : ""2""
    },
    ""deleted"" : false
  } ]
}
";
    }
}
