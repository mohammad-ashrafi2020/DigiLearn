using Newtonsoft.Json;

namespace TransactionModule.Services.ZarinPal.DTOs.UnVerification
{
    public class UnVerificationRequest
    {
        [JsonProperty("merchant_id")]
        public string MerchantId { get; set; }
    }
}