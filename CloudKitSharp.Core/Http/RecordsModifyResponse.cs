using CloudKitSharp.Core.Model;
using System.Text.Json.Serialization;

namespace CloudKitSharp.Core.Http
{
    /// <summary>
    /// Modifying Records (records/modify)
    /// </summary>
    /// <see cref="https://developer.apple.com/library/archive/documentation/DataManagement/Conceptual/CloudKitWebServicesReference/ModifyRecords.html#//apple_ref/doc/uid/TP40015240-CH2-SW9"/>
    public class RecordsModifyResponse<T>
    {
        /// <summary>
        /// An array containing a result dictionary for each operation in the request. If successful, the result dictionary contains the keys described in Record Dictionary. If unsuccessful, the result dictionary contains the keys described in Record Fetch Error Dictionary.
        /// </summary>
        [JsonPropertyName("records")]
        public List<RecordDictionary<T>>? records { get; set; }
    }
}
