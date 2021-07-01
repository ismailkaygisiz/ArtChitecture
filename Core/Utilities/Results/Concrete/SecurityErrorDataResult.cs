using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results.Concrete
{
    public class SecurityErrorDataResult<T> : DataResult<T>
    {
        public SecurityErrorDataResult(string securityError, string message) : base(default,
            false, message)
        {
            SecurityError = securityError;
        }

        public SecurityErrorDataResult(string securityError) : base(default, false)
        {
            SecurityError = securityError;
        }

        public SecurityErrorDataResult() : base(default, false)
        {
        }

        public string SecurityError{ get; }
    }
}
