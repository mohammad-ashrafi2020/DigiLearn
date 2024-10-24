namespace TransactionModule.Services.DTOs.Commands
{
    public class TransactionPaymentErrorCommand
    {
        public Guid TransactionId { get; set; }
        public string ErrorMessage { get; set; }
        public string Authority { get; set; }
        public long RefId { get; set; }
        public bool Canceled { get; set; } = false;
    }

}