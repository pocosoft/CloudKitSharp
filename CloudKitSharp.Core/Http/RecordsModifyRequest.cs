using CloudKitSharp.Core.Model;
using RestSharp;
using System.Text.Json.Serialization;

namespace CloudKitSharp.Core.Http
{
    public class RecordsModifyRequest<T> : ICKRequest
    {
        /// <summary>
        /// Modifying Records (records/modify)
        /// </summary>
        /// <see cref="https://developer.apple.com/library/archive/documentation/DataManagement/Conceptual/CloudKitWebServicesReference/ModifyRecords.html#//apple_ref/doc/uid/TP40015240-CH2-SW9"/>
        public Method Method => Method.Post;
        public string SubPath => $"/{_database}/records/modify";
        public object? Body => _parameter;
        private readonly CKDatabase _database;
        private readonly Parameter _parameter;
        public RecordsModifyRequest(CKDatabase database, Parameter parameter)
        {
            _database = database;
            _parameter = parameter;
        }
        public class Parameter
        {
            public RecordOperationDictionary<T> operations { get; set; } = new();
            public ZoneIDDictionary zoneID { get; set; } = new();

            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
            public bool numbersAsStrings { get; set; } = false;
        }
    }
}
