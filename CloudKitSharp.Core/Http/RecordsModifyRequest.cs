using CloudKitSharp.Core.Model;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CloudKitSharp.Core.Http
{
    public class RecordsModifyRequest : ICKRequest
    {
        /// <summary>
        /// Modifying Records (records/modify)
        /// </summary>
        /// <see cref="https://developer.apple.com/library/archive/documentation/DataManagement/Conceptual/CloudKitWebServicesReference/ModifyRecords.html#//apple_ref/doc/uid/TP40015240-CH2-SW9"/>
        public Method Method => Method.Post;
        public string SubPath => $"/{_database}/records/modify";
        public object? Body => _parameter;
        private CKDatabase _database { get; }
        private Parameter _parameter { get; }
        public RecordsModifyRequest(CKDatabase database, Parameter parameter)
        {
            _database = database;
            _parameter = parameter;
        }
        public class Parameter
        {
            public RecordOperationDictionary operations { get; set; }
            public ZoneIDDictionary zoneID { get; set; }

            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
            public bool numbersAsStrings { get; set; } = false;
        }
    }
}
