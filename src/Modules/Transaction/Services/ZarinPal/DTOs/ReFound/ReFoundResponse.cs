namespace TransactionModule.Services.ZarinPal.DTOs.ReFound
{
    public class ReFoundResponse
    {
        public List<FinalReFoundResponse> data { get; set; }
        public ReFoundErrorResponse errors { get; set; }
    }

    public class FinalReFoundResponse
    {
        public string code { get; set; }
        public string message { get; set; }
        public int ref_id { get; set; }
        public int session { get; set; }
        public string iban { get; set; }
    }

    public class ReFoundErrorResponse
    {
        public string message { get; set; }
        public int code { get; set; }
    }
}