namespace TransactionModule.Exceptions
{
    public class PaymentAmountIsLowException:Exception
    {
        public PaymentAmountIsLowException()
        {
            
        }

        public PaymentAmountIsLowException(string message):base(message)
        {
            
        }
    }
}