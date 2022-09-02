using System.Text.Json.Serialization;

namespace CloudKitSharp.Core.Model
{
    /// <summary>
    /// Record Dictionary
    /// </summary>
    /// <see cref="https://developer.apple.com/library/archive/documentation/DataManagement/Conceptual/CloudKitWebServicesReference/Types.html#//apple_ref/doc/uid/TP40015240-CH3-SW6"/>
    public class RecordDictionary<T> : CommonResponseKeys
    {
        /// <summary>
        /// The unique name used to identify the record within a zone.The default value is a random UUID.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? recordName { get; set; }

        /// <summary>
        /// The name of the record type. This key is required for certain operations if the record doesn’t exist.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? recordType { get; set; }

        /// <summary>
        /// A string containing the server change token for the record. Use this tag to indicate which version of the record you last fetched.
        /// This key is required if the operation type is update, replace, or delete.This key is not required if the operation is forceUpdate, forceReplace, or forceDelete.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? recordChangeTag { get; set; }

        /// <summary>
        /// The dictionary of key-value pairs whose keys are the record field names and values are field-value dictionaries, described in Record Field Dictionary. The default value is an empty dictionary.
        /// If the operation is create and this key is omitted or set to null, all fields in a newly created record are set to null.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public T? fields { get; set; }
    }
}
