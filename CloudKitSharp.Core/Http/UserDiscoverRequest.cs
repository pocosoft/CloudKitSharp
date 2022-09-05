using RestSharp;

namespace CloudKitSharp.Core.Http
{
    /// <summary>
    /// 
    /// </summary>
    public class UserDiscoverRequest : ICKRequest
    {
        public Method Method => Method.Post;

        public string SubPath => "/public/users/discover";

        public object? Body => null;
    }
}
