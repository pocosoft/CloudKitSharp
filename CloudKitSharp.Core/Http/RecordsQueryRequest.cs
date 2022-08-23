using CloudKitSharp.Core.Model;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudKitSharp.Core.Http
{
    public class RecordsQueryRequest : ICKRequest
    {
        public Method Method => Method.Post;

        public string SubPath => $"/{_database.ToString().ToLower()}/records/query";

        public object? Body => _body;

        private readonly CKDatabase _database;
        private readonly Parameter _body;
        public RecordsQueryRequest(CKDatabase database, Parameter body)
        {
            _database = database;
            _body = body;
        }
        public class Parameter
        {
            public QueryDictionary query { get; }
            public ZoneIDDictionary zoneID { get; }
            public Parameter(QueryDictionary query, ZoneIDDictionary zoneID)
            {
                this.query = query;
                this.zoneID = zoneID;
            }
        }
    }
}
