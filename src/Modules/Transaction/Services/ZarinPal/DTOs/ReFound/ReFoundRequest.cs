using Newtonsoft.Json;

namespace TransactionModule.Services.ZarinPal.DTOs.ReFound
{
    public class ReFoundRequest
    {
        [JsonProperty("merchant_id")]
        public string MerchantId { get; set; }

        [JsonProperty("authority")]
        public string Authority { get; set; }

    }
}