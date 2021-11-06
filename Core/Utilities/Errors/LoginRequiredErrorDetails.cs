using Core.Utilities.Exceptions;

namespace Core.Utilities.Errors
{
    public class LoginRequiredErrorDetails : ErrorDetails
    {
        public LoginRequiredErrorDetails(string errorMessage, string securityError) : base(401, errorMessage, ExceptionType.LoginRequiredException)
        {
            SecurityError = securityError;
        }

        public LoginRequiredErrorDetails(int statusCode, string errorMessage, string securityError) : base(statusCode, errorMessage, ExceptionType.LoginRequiredException)
        {
            SecurityError = securityError;
        }

        public string SecurityError { get; set; }
    }
}
