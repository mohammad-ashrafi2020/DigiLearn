using Newtonsoft.Json;

namespace TransactionModule.Services.ZarinPal.DTOs.Payment
{
    public class PaymentResponse
    {
        public PaymentResponseData Data { get; set; }
    }

    public class PaymentResponseData
    {
        [JsonProperty("code")]
        public int Status { get; set; }

        [JsonProperty("authority")]
        public string Authority { get; set; }

        [JsonProperty("fee")]
        public int Fee { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
        public string GateWayUrl { get; set; }
    }

    public class SandBoxPaymentResponse
    {
        public int Status { get; set; }
        public string Authority { get; set; }
    }
}
