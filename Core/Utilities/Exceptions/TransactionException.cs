namespace Core.Utilities.Exceptions
{
    public class TransactionException : BaseException
    {
        public string TransactionError { get; set; }

        public TransactionException(string exceptionMessage, string transactionError) : base(400, ExceptionType.TransactionException, exceptionMessage)
        {
            TransactionError = transactionError;
        }

        public TransactionException(int statusCode, string exceptionMessage, string transactionError) : base(statusCode, ExceptionType.TransactionException, exceptionMessage)
        {
            TransactionError = transactionError;
        }
    }
}
