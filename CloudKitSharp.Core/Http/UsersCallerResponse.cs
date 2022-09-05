using System.Text.Json.Serialization;

namespace CloudKitSharp.Core.Http
{
    public class UsersCallerResponse
    {
        [JsonPropertyName("userRecordName")]
        public string? UserRecordName { get; set; }
    }
}
