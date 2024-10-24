using Newtonsoft.Json;

namespace TransactionModule.Services.ZarinPal.DTOs.UnVerification
{
    public class UnVerificationResponse
    {
        [JsonProperty("data")]
        public UnVerificationFinallyResponse Data { get; set; }
        public List<object> errors { get; set; }
    }

    public class UnVerificationFinallyResponse
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("authorities")]
        public List<UnVerificationResponseItem> Authorities { get; set; }
    }
}