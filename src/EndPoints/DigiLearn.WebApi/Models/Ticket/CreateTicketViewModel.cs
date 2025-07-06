namespace DigiLearn.WebApi.Models.Ticket
{
    public class CreateTicketViewModel
    {
        public string OwnerFullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
    }
    public class SendTicketMessageViewModel
    {
        public Guid TicketId { get; set; }
        public string OwnerFullName { get; set; }
        public string Text { get; set; }
    }
}
