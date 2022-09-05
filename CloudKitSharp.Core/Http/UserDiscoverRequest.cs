using RestSharp;

namespace CloudKitSharp.Core.Http
{
    /// <summary>
    /// Discovering All User Identities (GET users/discover)
    /// Fetches all user identities in the current user’s address book.
    /// </summary>
    /// <see cref="https://developer.apple.com/library/archive/documentation/DataManagement/Conceptual/CloudKitWebServicesReference/DiscoveringAllUserIdentities.html#//apple_ref/doc/uid/TP40015240-CH31-SW1"/>
    public class UserDiscoverRequest : ICKRequest
    {
        public Method Method => Method.Get;

        public string SubPath => "/public/users/discover";

        public object? Body => null;
    }
}
