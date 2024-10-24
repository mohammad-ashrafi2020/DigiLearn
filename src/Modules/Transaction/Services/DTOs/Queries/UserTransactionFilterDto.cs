using Common.Application;
using TransactionModule.Domain;

namespace TransactionModule.Services.DTOs.Queries
{
    public class UserTransactionFilterParams
    {
        public int PageId { get; set; } = 1;
        public int Take { get; set; } = 20;
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public TransactionStatus? Status { get; set; }
        public TransactionFor? TransactionFor { get; set; }
        public Guid? UserId { get; set; }
    }

    public class UserTransactionFilterDto : PaginateBase
    {
        public UserTransactionFilterParams Filters { get; set; }
        public List<UserTransactionDto> Transactions { get; set; }
        public int TotalPayment { get; set; }
    }
}