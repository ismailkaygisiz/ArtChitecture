using Core.Utilities.Exceptions;

namespace Core.Utilities.Errors
{
    public class UnAuthorizedErrorDetails : ErrorDetails
    {
        public UnAuthorizedErrorDetails(string errorMessage, string securityError) : base(401, errorMessage, ExceptionType.UnAuthorizedException)
        {
            SecurityError = securityError;
        }

        public UnAuthorizedErrorDetails(int statusCode, string errorMessage, string securityError) : base(statusCode, errorMessage, ExceptionType.UnAuthorizedException)
        {
            SecurityError = securityError;
        }

        public string SecurityError { get; set; }
    }
}
