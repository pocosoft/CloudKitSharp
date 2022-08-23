using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CloudKitSharp.Core.Model
{
    /// <summary>
    /// https://developer.apple.com/library/archive/documentation/DataManagement/Conceptual/CloudKitWebServicesReference/Types.html#//apple_ref/doc/uid/TP40015240-CH3-SW15
    /// </summary>
    public class QueryDictionary
    {
        public string recordType { get; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public FilterDictionary? filterBy;
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public SortDescriptorDictionary? sortBy;
        public QueryDictionary(string recordType, FilterDictionary? filterBy = null, SortDescriptorDictionary? sortBy = null)
        {
            this.recordType = recordType;
            this.filterBy = filterBy;
            this.sortBy = sortBy;
        }
    }
}
