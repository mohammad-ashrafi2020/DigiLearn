using Newtonsoft.Json;

namespace TransactionModule.Services.ZarinPal.DTOs.UnVerification
{
    public class UnVerificationResponseItem
    {
        [JsonProperty("authority")]
        public string Authority { get; set; }

        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("callback_url")]
        public string CallbackUrl { get; set; }

        [JsonProperty("referer")]
        public string Referer { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }
    }
}