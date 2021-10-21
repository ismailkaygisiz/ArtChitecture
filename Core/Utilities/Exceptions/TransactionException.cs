namespace Core.Utilities.Exceptions
{
    public class TransactionException : BaseExceptionResult
    {
        public string TransactionError { get; set; }

        public TransactionException(string exceptionMessage, string transactionError)
        {
            ExceptionType = ExceptionType.TransactionException;
            ExceptionMessage = exceptionMessage;
            StatusCode = 400;
            TransactionError = transactionError;
        }

        public TransactionException(string exceptionMessage, int statusCode, string transactionError)
        {
            ExceptionType = ExceptionType.TransactionException;
            ExceptionMessage = exceptionMessage;
            StatusCode = statusCode;
            TransactionError = transactionError;
        }
    }
}
