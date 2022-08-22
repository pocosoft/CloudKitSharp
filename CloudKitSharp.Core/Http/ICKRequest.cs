using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudKitSharp.Core.Http
{
    public interface ICKRequest
    {
        public string SubPath { get; }
        public object Body { get; }
        public string Container { get; }
        public string Path => "https://api.apple-cloudkit.com";
        public string Url => $"{Path}/database/1/{Container}/{Environment.ToString().ToLower()}/{SubPath}";

        public CKEnvironment Environment
        {
            get
            {
#if DEBUG
                return CKEnvironment.Development;
#else
                return CKEnvironment.Prodiction;
#endif
            }
        }
    }
}