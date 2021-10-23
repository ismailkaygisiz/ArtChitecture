using Core.Utilities.Exceptions;

namespace Core.Utilities.Errors
{
    public class TransactionErrorDetails : ErrorDetails
    {
        public TransactionErrorDetails(string errorMessage, string transactionError) : base(400, errorMessage, ExceptionType.TransactionException)
        {
            TransactionError = transactionError;
        }

        public TransactionErrorDetails(int statusCode, string errorMessage, string transactionError) : base(statusCode, errorMessage, ExceptionType.TransactionException)
        {
            TransactionError = transactionError;
        }

        public string TransactionError { get; set; }
    }
}
