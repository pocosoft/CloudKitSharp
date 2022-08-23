﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace CloudKitSharp.Core.Http
{
    public interface ICKRequest
    {
        public Method Method { get;  }
        public string SubPath { get; }
        public object? Body { get; }
        public string Path => "https://api.apple-cloudkit.com";
        public string GetUrl(string container) => $"{Path}/database/1/{container}/{Environment.ToString().ToLower()}{SubPath}";

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