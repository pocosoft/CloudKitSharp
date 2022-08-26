using RestSharp;

namespace CloudKitSharp.Core.Http
{
    public class UsersCallerRequest : ICKRequest
    {
        public Method Method => Method.Get;
        public string SubPath => "/public/users/caller";

        public object? Body => null;
    }
}
