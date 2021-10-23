using System.Collections.Generic;

namespace Core.Utilities.Exceptions
{
    public class ValidationException : BaseException
    {
        public List<string> ValidationErrors { get; set; }

        public ValidationException(string exceptionMessage, List<string> validationErrors) : base(400, ExceptionType.ValidationException, exceptionMessage)
        {
            ValidationErrors = validationErrors;
        }

        public ValidationException(int statusCode, string exceptionMessage, List<string> validationErrors) : base(statusCode, ExceptionType.ValidationException, exceptionMessage)
        {
            ValidationErrors = validationErrors;
        }
    }
}
