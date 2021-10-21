using System.Collections.Generic;

namespace Core.Utilities.Exceptions
{
    public class ValidationException : BaseExceptionResult
    {
        public List<string> ValidationErrors { get; set; }

        public ValidationException(string exceptionMessage, List<string> validationErrors)
        {
            ExceptionType = ExceptionType.ValidationException;
            ExceptionMessage = exceptionMessage;
            StatusCode = 400;
            ValidationErrors = validationErrors;
        }

        public ValidationException(string exceptionMessage, int statusCode, List<string> validationErrors)
        {

            ExceptionType = ExceptionType.ValidationException;
            ExceptionMessage = exceptionMessage;
            StatusCode = statusCode;
            ValidationErrors = validationErrors;
        }
    }
}
