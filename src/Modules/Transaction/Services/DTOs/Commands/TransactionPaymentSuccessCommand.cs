namespace TransactionModule.Services.DTOs.Commands
{
    public class TransactionPaymentSuccessCommand
    {
        public Guid TransactionId { get; set; }
        public string Authority { get; set; }
        public long RefId { get; set; }
        public string CardPen { get; set; }
        public string SuccessCallBack { get; set; }
    }
}