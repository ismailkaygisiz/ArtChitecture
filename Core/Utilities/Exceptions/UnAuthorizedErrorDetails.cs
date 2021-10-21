using Newtonsoft.Json;

namespace Core.Utilities.Exceptions
{
    public class UnAuthorizedErrorDetails : ErrorDetails
    {
        public string SecurityError { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
