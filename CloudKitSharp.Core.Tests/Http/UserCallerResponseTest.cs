using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using CloudKitSharp.Core.Http;

namespace CloudKitSharp.Core.Tests.Http
{
    public class UserCallerResponseTest
    {
        [Fact]
        public void JsonParseTest()
        {
            var jsonString = @"
{
""userRecordName"" : ""_d8e2b6c17258c644a282008756152412""
}
";
            var result = JsonSerializer.Deserialize<CloudKitSharp.Core.Http.UsersCallerResponse>(jsonString);
            Assert.Equal(result?.UserRecordName, "_d8e2b6c17258c644a282008756152412");
        }
    }
}
