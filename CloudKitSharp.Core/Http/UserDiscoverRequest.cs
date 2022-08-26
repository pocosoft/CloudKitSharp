using RestSharp;

namespace CloudKitSharp.Core.Http
{
    public class UserDiscoverRequest : ICKRequest
    {
        public Method Method => Method.Get;

        public string SubPath => "/public/users/discover";

        public object? Body => null;
    }
}
