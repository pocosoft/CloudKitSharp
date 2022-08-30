using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CloudKitSharp.Core.Http
{
    /// <summary>
    /// A CKValue represents a field type value.The table shows the supported field types.
    /// </summary>
    /// <see cref="https://developer.apple.com/library/archive/documentation/DataManagement/Conceptual/CloudKitWebServicesReference/Types.html#//apple_ref/doc/uid/TP40015240-CH3-SW1"/>
    public class CKValue<T>
    {
        [JsonPropertyName("value")]
        public T value { get; set; }
        [JsonPropertyName("type")]
        public string type
        {
            get
            {
                if (value?.GetType() == typeof(int) || value?.GetType() == typeof(long))
                {
                    return "INT64";
                }
                else if (value?.GetType() == typeof(string))
                {
                    return "STRING";
                }
                else
                {
                    throw new NotSupportedException();
                }
            }
        }
    }
}
