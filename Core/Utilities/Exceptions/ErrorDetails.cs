

using Newtonsoft.Json;

namespace Core.Utilities.Exceptions
{
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }
        public ExceptionType ExceptionType { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}