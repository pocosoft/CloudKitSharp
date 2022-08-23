using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
