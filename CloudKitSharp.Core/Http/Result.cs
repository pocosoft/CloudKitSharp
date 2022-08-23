using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudKitSharp.Core.Http
{
    public class Result<T>
    {
        public T? Response { get; }
        public CKError? Error { get; }
        public Result(T response)
        {
            Response = response;
            Error = null;
        }
        public Result(CKError error)
        {
            Response = default(T);
            Error = error;
        }
        public bool IsSuccess
        {
            get
            {
                return Error == null;
            }
        }
    }
}
