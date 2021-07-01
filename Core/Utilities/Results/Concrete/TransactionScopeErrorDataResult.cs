using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results.Concrete
{
    public class TransactionScopeErrorDataResult<T> : DataResult<T>
    {
        public TransactionScopeErrorDataResult(string transactionScopeError, string message) : base(default,
            false, message)
        {
            TransactionScopeError = transactionScopeError;
        }

        public TransactionScopeErrorDataResult(string transactionScopeError) : base(default, false)
        {
            TransactionScopeError = transactionScopeError;
        }

        public TransactionScopeErrorDataResult() : base(default, false)
        {
        }

        public string TransactionScopeError { get; }
    }
}
