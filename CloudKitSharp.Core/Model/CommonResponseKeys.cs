using System.Text.Json.Serialization;

namespace CloudKitSharp.Core.Model
{
    /// <summary>
    /// Common Response Keys
    /// These record keys appear in responses:
    /// </summary>
    /// <see cref=""/>
    public abstract class CommonResponseKeys
    {

        [JsonPropertyName("created")]
        public DateTimeKeys? created { get; set; }
        [JsonPropertyName("modified")]
        public DateTimeKeys? modified { get; set; }
        [JsonPropertyName("deleted")]
        public bool deleted { get; set; } = false;
        public class DateTimeKeys
        {
            [JsonPropertyName("timestamp"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
            public long timestamp { get; set; } = -1;
            [JsonPropertyName("userRecordName"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
            public string? userRecordName { get; set; }
            [JsonPropertyName("deviceID"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
            public string? deviceID { get; set; }
        }
    }
}
