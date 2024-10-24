using Newtonsoft.Json;

namespace TransactionModule.Services.ZarinPal.DTOs.Verification
{
    public class VerificationRequest
    {
        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("merchant_id")]
        public string MerchantId { get; set; }

        [JsonProperty("authority")]
        public string Authority { get; set; }
    }
}
