using Core.Utilities.Exceptions;

namespace Core.Utilities.Errors
{
    public class AuthorizationDeniedErrorDetails : ErrorDetails
    {
        public AuthorizationDeniedErrorDetails(string errorMessage, string securityError) : base(403, errorMessage, ExceptionType.AuthorizationDeniedException)
        {
            SecurityError = securityError;
        }

        public AuthorizationDeniedErrorDetails(int statusCode, string errorMessage, string securityError) : base(statusCode, errorMessage, ExceptionType.AuthorizationDeniedException)
        {
            SecurityError = securityError;
        }

        public string SecurityError { get; set; }
    }
}
