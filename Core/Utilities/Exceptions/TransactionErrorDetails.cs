using Newtonsoft.Json;

namespace Core.Utilities.Exceptions
{
    public class TransactionErrorDetails : ErrorDetails
    {
        public string TransactionError { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
