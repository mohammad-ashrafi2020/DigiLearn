using Common.Domain;
using TransactionModule.Exceptions;

namespace TransactionModule.Domain
{
    public class UserTransaction : BaseEntity
    {
        public Guid UserId { get; private set; }
        public int PaymentAmount { get; private set; }
        public Guid PaymentLinkId { get; private set; }
        public long? RefId { get; private set; }
        public string? Authority { get; private set; }
        public string? CardPan { get; private set; }
        public string? PaymentErrorMessage { get; private set; }
        public string? PaymentGateway { get; private set; }
        public TransactionStatus Status { get; private set; }
        public TransactionFor TransactionFor { get; private set; }
        public DateTime CreateDate { get; private set; }
        public DateTime? PaymentDate { get; private set; }

        private UserTransaction()
        {
        }

        public UserTransaction(Guid userId, int paymentAmount, TransactionFor transactionFor, Guid paymentLinkId, PaymentGateway paymentGateWay)
        {
            if (paymentAmount < 1000)
                throw new PaymentAmountIsLowException();
            UserId = userId;
            PaymentAmount = paymentAmount;
            TransactionFor = transactionFor;
            PaymentLinkId = paymentLinkId;
            PaymentGateway = paymentGateWay.ToString();
            CreateDate = DateTime.Now;
        }

        public void PaymentSuccess(string authority, string cardPan, long refId)
        {
            Authority = authority;
            CardPan = cardPan;
            RefId = refId;
            Status = TransactionStatus.PaymentSuccess;
            PaymentDate = DateTime.Now;
        }

        public void PaymentError(string paymentErrorMessage, long refId, string authority, bool isCanceled)
        {
            PaymentErrorMessage = paymentErrorMessage;
            RefId = refId;
            Authority = authority;
            if (isCanceled)
                Status = TransactionStatus.CancelPayment;
            else
                Status = TransactionStatus.PaymentError;
        }
    }
}