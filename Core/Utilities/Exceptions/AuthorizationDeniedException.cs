namespace Core.Utilities.Exceptions
{
    public class AuthorizationDeniedException : BaseException
    {
        public string SecurityError { get; set; }

        public AuthorizationDeniedException(string exceptionMessage, string securityError) : base(403, ExceptionType.AuthorizationDeniedException, exceptionMessage)
        {
            SecurityError = securityError;
        }

        public AuthorizationDeniedException(int statusCode, string exceptionMessage, string securityError) : base(statusCode, ExceptionType.AuthorizationDeniedException, exceptionMessage)
        {
            SecurityError = securityError;
        }
    }
}
