using System;

namespace Core.Utilities.Exceptions
{
    public abstract class BaseExceptionResult : Exception
    {
        public int StatusCode { get; set; }
        public ExceptionType ExceptionType { get; set; }
        public string ExceptionMessage { get; set; }
    }

    public enum ExceptionType
    {
        TransactionException,
        UnAuthorizedException,
        ValidationException,
        SystemException,
    }
}
