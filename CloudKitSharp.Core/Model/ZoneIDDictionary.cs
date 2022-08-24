using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudKitSharp.Core.Model
{
    /// <summary>
    /// Zone ID Dictionary
    /// </summary>
    /// <see cref="https://developer.apple.com/library/archive/documentation/DataManagement/Conceptual/CloudKitWebServicesReference/Types.html#//apple_ref/doc/uid/TP40015240-CH3-SW9"/>
    public class ZoneIDDictionary
    {
        /// <summary>
        /// The name that identifies the record zone. The default value is _defaultZone, which indicates the default zone of the current database. This key is required.
        /// </summary>
        public string zoneName { get; }
        public ZoneIDDictionary(string zoneName)
        {
            this.zoneName = zoneName;
        }
    }
}
