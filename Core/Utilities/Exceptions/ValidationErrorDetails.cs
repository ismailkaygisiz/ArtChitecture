using Newtonsoft.Json;
using System.Collections.Generic;

namespace Core.Utilities.Exceptions
{
    public class ValidationErrorDetails : ErrorDetails
    {
        public List<string> ValidationErrors { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
