using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudKitSharp.Core.Model
{
    /// <summary>
    /// Operation Type Values
    /// </summary>
    /// <see cref="https://developer.apple.com/library/archive/documentation/DataManagement/Conceptual/CloudKitWebServicesReference/ModifyRecords.html#//apple_ref/doc/uid/TP40015240-CH2-SW5"/>
    public enum OperationTypeValues
    {
        create, update, forceUpdate, replace, forceReplace, delete, forceDelete
    }
}
