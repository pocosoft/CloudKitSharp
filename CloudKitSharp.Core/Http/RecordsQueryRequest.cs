using CloudKitSharp.Core.Model;
using RestSharp;

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
            public QueryDictionary query { get; set; } = new();
            public ZoneIDDictionary zoneID { get; set; } = new();
        }
    }
}
