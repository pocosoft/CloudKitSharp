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
    public class RecordsQueryResponseTest
    {
        [Fact]
        public void JsonParseTest()
        {
            var result = JsonSerializer.Deserialize<RecordsQueryResponse<Items>>(jsonString);
            Assert.NotNull(result);
            Assert.NotNull(result?.records);
            Assert.Equal(5, result?.records?.Count);
            var firstRecord = result?.records?.First();
            Assert.Equal("0C0AEA6E-4CE9-5879-94C9-78363AD67ABD", firstRecord!.recordName);
            Assert.Equal(150, firstRecord!.fields?.price?.value);
            Assert.Equal(40, firstRecord!.fields?.count?.value);
            Assert.Equal("Orange", firstRecord!.fields?.name?.value);
            Assert.Equal("_d8e2b6c17258c644a282008756152412", firstRecord?.modified?.userRecordName);
            Assert.Equal(1661798543871, firstRecord?.modified?.timestamp);
        }

        public class Items
        {
            [JsonPropertyName("price")]
            public CKValue<int>? price { get; set; }

            [JsonPropertyName("count")]
            public CKValue<int>? count { get; set; }
            
            [JsonPropertyName("name")]
            public CKValue<string>? name { get; set; }
        }

        private string jsonString = @"
{
  ""records"" : [ {
    ""recordName"" : ""0C0AEA6E-4CE9-5879-94C9-78363AD67ABD"",
    ""recordType"" : ""Items"",
    ""fields"" : {
      ""price"" : {
        ""value"" : 150,
        ""type"" : ""INT64""
      },
      ""count"" : {
        ""value"" : 40,
        ""type"" : ""INT64""
      },
      ""name"" : {
        ""value"" : ""Orange"",
        ""type"" : ""STRING""
      },
      ""updateTime"" : {
        ""value"" : 1661744539407,
        ""type"" : ""TIMESTAMP""
      }
    },
    ""pluginFields"" : { },
    ""recordChangeTag"" : ""l7603c0g"",
    ""created"" : {
      ""timestamp"" : 1661247875019,
      ""userRecordName"" : ""_d8e2b6c17258c644a282008756152412"",
      ""deviceID"" : ""2""
    },
    ""modified"" : {
      ""timestamp"" : 1661798543871,
      ""userRecordName"" : ""_d8e2b6c17258c644a282008756152412"",
      ""deviceID"" : ""2""
    },
    ""deleted"" : false,
    ""zoneID"" : {
      ""zoneName"" : ""_defaultZone"",
      ""ownerRecordName"" : ""_d8e2b6c17258c644a282008756152412"",
      ""zoneType"" : ""DEFAULT_ZONE""
    }
  }, {
    ""recordName"" : ""50297A8A-1A45-AA3D-6A6B-9CE82013C69C"",
    ""recordType"" : ""Items"",
    ""fields"" : {
      ""price"" : {
        ""value"" : 100,
        ""type"" : ""INT64""
      },
      ""count"" : {
        ""value"" : 30,
        ""type"" : ""INT64""
      },
      ""name"" : {
        ""value"" : ""Apple"",
        ""type"" : ""STRING""
      },
      ""updateTime"" : {
        ""value"" : 1661830949728,
        ""type"" : ""TIMESTAMP""
      }
    },
    ""pluginFields"" : { },
    ""recordChangeTag"" : ""l7600qny"",
    ""created"" : {
      ""timestamp"" : 1661247753994,
      ""userRecordName"" : ""_d8e2b6c17258c644a282008756152412"",
      ""deviceID"" : ""2""
    },
    ""modified"" : {
      ""timestamp"" : 1661798554586,
      ""userRecordName"" : ""_d8e2b6c17258c644a282008756152412"",
      ""deviceID"" : ""2""
    },
    ""deleted"" : false,
    ""zoneID"" : {
      ""zoneName"" : ""_defaultZone"",
      ""ownerRecordName"" : ""_d8e2b6c17258c644a282008756152412"",
      ""zoneType"" : ""DEFAULT_ZONE""
    }
  }, {
    ""recordName"" : ""A1188011-5CB0-7436-6450-B88F66557644"",
    ""recordType"" : ""Items"",
    ""fields"" : {
      ""price"" : {
        ""value"" : 400,
        ""type"" : ""INT64""
      },
      ""count"" : {
        ""value"" : 40,
        ""type"" : ""INT64""
      },
      ""name"" : {
        ""value"" : ""Peaches"",
        ""type"" : ""STRING""
      }
    },
    ""pluginFields"" : { },
    ""recordChangeTag"" : ""l7604yp3"",
    ""created"" : {
      ""timestamp"" : 1661247951030,
      ""userRecordName"" : ""_d8e2b6c17258c644a282008756152412"",
      ""deviceID"" : ""2""
    },
    ""modified"" : {
      ""timestamp"" : 1661247951030,
      ""userRecordName"" : ""_d8e2b6c17258c644a282008756152412"",
      ""deviceID"" : ""2""
    },
    ""deleted"" : false,
    ""zoneID"" : {
      ""zoneName"" : ""_defaultZone"",
      ""ownerRecordName"" : ""ffffffffffffffff"",
      ""zoneType"" : ""DEFAULT_ZONE""
    }
  }, {
    ""recordName"" : ""A3D1F6B0-6EF2-16E5-FF20-6E15833F5B9F"",
    ""recordType"" : ""Items"",
    ""fields"" : {
      ""price"" : {
        ""value"" : 60,
        ""type"" : ""INT64""
      },
      ""count"" : {
        ""value"" : 30,
        ""type"" : ""INT64""
      },
      ""name"" : {
        ""value"" : ""Banana"",
        ""type"" : ""STRING""
      }
    },
    ""pluginFields"" : { },
    ""recordChangeTag"" : ""l7601kis"",
    ""created"" : {
      ""timestamp"" : 1661247792689,
      ""userRecordName"" : ""_d8e2b6c17258c644a282008756152412"",
      ""deviceID"" : ""2""
    },
    ""modified"" : {
      ""timestamp"" : 1661247792689,
      ""userRecordName"" : ""_d8e2b6c17258c644a282008756152412"",
      ""deviceID"" : ""2""
    },
    ""deleted"" : false,
    ""zoneID"" : {
      ""zoneName"" : ""_defaultZone"",
      ""ownerRecordName"" : ""ffffffffffffffff"",
      ""zoneType"" : ""DEFAULT_ZONE""
    }
  }, {
    ""recordName"" : ""BD63F2A7-91AE-253E-81E1-CF5B58514550"",
    ""recordType"" : ""Items"",
    ""fields"" : {
      ""price"" : {
        ""value"" : 210,
        ""type"" : ""INT64""
      },
      ""count"" : {
        ""value"" : 25,
        ""type"" : ""INT64""
      },
      ""name"" : {
        ""value"" : ""Cranberries"",
        ""type"" : ""STRING""
      }
    },
    ""pluginFields"" : { },
    ""recordChangeTag"" : ""l7602x9b"",
    ""created"" : {
      ""timestamp"" : 1661247855851,
      ""userRecordName"" : ""_d8e2b6c17258c644a282008756152412"",
      ""deviceID"" : ""2""
    },
    ""modified"" : {
      ""timestamp"" : 1661247855851,
      ""userRecordName"" : ""_d8e2b6c17258c644a282008756152412"",
      ""deviceID"" : ""2""
    },
    ""deleted"" : false,
    ""zoneID"" : {
      ""zoneName"" : ""_defaultZone"",
      ""ownerRecordName"" : ""ffffffffffffffff"",
      ""zoneType"" : ""DEFAULT_ZONE""
    }
  } ]
}";
    }
}
