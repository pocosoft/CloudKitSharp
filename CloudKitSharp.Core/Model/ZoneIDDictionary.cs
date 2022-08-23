using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudKitSharp.Core.Model
{
    public class ZoneIDDictionary
    {
        public string zoneName { get; }
        public ZoneIDDictionary(string zoneName)
        {
            this.zoneName = zoneName;
        }
    }
}
