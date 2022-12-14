namespace CloudKitSharp.Core.Model
{
    /// <summary>
    /// Record Operation Dictionary
    /// </summary>
    /// <see cref="https://developer.apple.com/library/archive/documentation/DataManagement/Conceptual/CloudKitWebServicesReference/ModifyRecords.html#//apple_ref/doc/uid/TP40015240-CH2-SW1"/>
    public class RecordOperationDictionary<T>
    {
        public OperationTypeValues operationType { get; set; } = OperationTypeValues.update;
        public RecordDictionary<T> record { get; set; } = new();
    }
}
