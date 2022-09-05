using RestSharp;

namespace CloudKitSharp.Core.Http
{
    /// <summary>
    /// Fetching Current User Identity (users/caller)
    /// </summary>
    /// <see cref="https://developer.apple.com/library/archive/documentation/DataManagement/Conceptual/CloudKitWebServicesReference/FetchCurrentUserIdentity.html#//apple_ref/doc/uid/TP40015240-CH27-SW1"/>
    public class UsersCallerRequest : ICKRequest
    {
        public Method Method => Method.Get;
        public string SubPath => "/public/users/caller";

        public object? Body => null;
    }
}
