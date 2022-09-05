using CloudKitSharp.Core.Model;
using System.Text.Json.Serialization;

namespace CloudKitSharp.Core.Http
{
    /// <summary>
    /// Response
    /// An array of dictionaries describing the results of the operation. The dictionary contains the following keys:
    /// </summary>
    /// <see cref="https://developer.apple.com/library/archive/documentation/DataManagement/Conceptual/CloudKitWebServicesReference/QueryingRecords.html#//apple_ref/doc/uid/TP40015240-CH5-SW4"/>
    /// <typeparam name="T"></typeparam>
    public class RecordsQueryResponse<T>
    {
        /// <summary>
        /// An array containing a result dictionary for each record requested. If successful, the result dictionary contains the keys described in Record Dictionary. If unsuccessful, the result dictionary contains the keys described in Record Fetch Error Dictionary.
        /// </summary>
        [JsonPropertyName("records")]
        public List<RecordDictionary<T>>? records { get; set; }
    }
}
