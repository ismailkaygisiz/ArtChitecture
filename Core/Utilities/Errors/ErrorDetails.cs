using Core.Utilities.Exceptions;
using Newtonsoft.Json;

namespace Core.Utilities.Errors
{
    public class ErrorDetails
    {
        public ErrorDetails(int statusCode, string errorMessage, ExceptionType exceptionType)
        {
            StatusCode = statusCode;
            ErrorMessage = errorMessage;
            ExceptionType = exceptionType;
        }

        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }
        public ExceptionType ExceptionType { get; set; }

        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}