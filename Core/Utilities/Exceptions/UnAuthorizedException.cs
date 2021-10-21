namespace Core.Utilities.Exceptions
{
    public class UnAuthorizedException : BaseExceptionResult
    {
        public string SecurityError { get; set; }

        public UnAuthorizedException(string exceptionMessage, string unAuthorizedExceptionMessage)
        {
            ExceptionType = ExceptionType.UnAuthorizedException;
            ExceptionMessage = exceptionMessage;
            StatusCode = 401;
            SecurityError = unAuthorizedExceptionMessage;
        }

        public UnAuthorizedException(string exceptionMessage, int statusCode, string unAuthorizedExceptionMessage)
        {
            ExceptionType = ExceptionType.UnAuthorizedException;
            ExceptionMessage = exceptionMessage;
            StatusCode = statusCode;
            SecurityError = unAuthorizedExceptionMessage;
        }
    }
}
