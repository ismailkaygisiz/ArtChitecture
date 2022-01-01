using System;

namespace Core.Utilities.Exceptions
{
    [Serializable]
    public abstract class BaseException : Exception
    {
        protected BaseException(int statusCode, ExceptionType exceptionType, string exceptionMessage) : base(exceptionMessage)
        {
            StatusCode = statusCode;
            ExceptionType = exceptionType;
            ExceptionMessage = exceptionMessage;
        }

        public int StatusCode { get; set; }
        public ExceptionType ExceptionType { get; set; }
        public string ExceptionMessage { get; set; }
    }

    public enum ExceptionType
    {
        TransactionException,
        AuthorizationDeniedException,
        LoginRequiredException,
        ValidationException,
        SystemException,
    }
}
