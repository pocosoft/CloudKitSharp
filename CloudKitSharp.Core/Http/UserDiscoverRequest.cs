using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudKitSharp.Core.Http
{
    public class UserDiscoverRequest : ICKRequest
    {
        public Method Method => Method.Get;

        public string SubPath => "/public/users/discover";

        public object? Body => null;
    }
}
