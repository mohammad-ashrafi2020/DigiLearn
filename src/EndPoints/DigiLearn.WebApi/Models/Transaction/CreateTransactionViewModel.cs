using TransactionModule.Domain;

namespace DigiLearn.WebApi.Models.Transaction
{
    public class CreateTransactionViewModel
    {
        public int PaymentAmount { get; set; }
        public Guid LinkId { get; set; }
        public PaymentGateway PaymentGateway { get; set; }
        public TransactionFor TransactionFor { get; set; }
    }
    public class UserTransactionFilterParamsViewModel
    {
        public int PageId { get; set; } = 1;
        public int Take { get; set; } = 20;
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public TransactionStatus? Status { get; set; }
        public TransactionFor? TransactionFor { get; set; }
    }
}
