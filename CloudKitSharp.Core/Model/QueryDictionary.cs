using System.Text.Json.Serialization;

namespace CloudKitSharp.Core.Model
{
    /// <summary>
    /// Query Dictionary
    /// </summary>
    /// <see cref="https://developer.apple.com/library/archive/documentation/DataManagement/Conceptual/CloudKitWebServicesReference/Types.html#//apple_ref/doc/uid/TP40015240-CH3-SW15"/>
    public class QueryDictionary
    {
        /// <summary>
        /// The name of the record type. This key is required.
        /// </summary>
        public string recordType { get; set; } = "";
        /// <summary>
        /// An Array of filter dictionaries (described in Filter Dictionary) used to determine whether a record matches the query.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public FilterDictionary? filterBy { get; set; }
        /// <summary>
        /// An Array of sort descriptor dictionaries (described in Sort Descriptor Dictionary) that specify how to order the fetched records.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public SortDescriptorDictionary? sortBy { get; set; }
    }
}
