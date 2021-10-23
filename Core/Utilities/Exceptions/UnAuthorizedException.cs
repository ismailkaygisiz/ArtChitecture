namespace Core.Utilities.Exceptions
{
    public class UnAuthorizedException : BaseException
    {
        public string SecurityError { get; set; }

        public UnAuthorizedException(string exceptionMessage, string unAuthorizedExceptionMessage) : base(401, ExceptionType.UnAuthorizedException, exceptionMessage)
        {
            SecurityError = unAuthorizedExceptionMessage;
        }

        public UnAuthorizedException(int statusCode, string exceptionMessage, string unAuthorizedExceptionMessage) : base(statusCode, ExceptionType.UnAuthorizedException, exceptionMessage)
        {
            SecurityError = unAuthorizedExceptionMessage;
        }
    }
}
