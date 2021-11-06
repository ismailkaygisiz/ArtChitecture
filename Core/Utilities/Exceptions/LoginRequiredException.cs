namespace Core.Utilities.Exceptions
{
    public class LoginRequiredException : BaseException
    {
        public string SecurityError { get; set; }

        public LoginRequiredException(string exceptionMessage, string securityError) : base(401, ExceptionType.LoginRequiredException, exceptionMessage)
        {
            SecurityError = securityError;
        }

        public LoginRequiredException(int statusCode, string exceptionMessage, string securityError) : base(statusCode, ExceptionType.LoginRequiredException, exceptionMessage)
        {
            SecurityError = securityError;
        }
    }
}
