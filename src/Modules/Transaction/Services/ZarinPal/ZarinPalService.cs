using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using TransactionModule.Services.ZarinPal.DTOs.Payment;
using TransactionModule.Services.ZarinPal.DTOs.ReFound;
using TransactionModule.Services.ZarinPal.DTOs.UnVerification;
using TransactionModule.Services.ZarinPal.DTOs.Verification;

namespace TransactionModule.Services.ZarinPal
{
    public class ZarinPalService : IZarinPalService
    {
        private string MerchantId { get; }
        private string PaymentUrl { get; }
        private string VerifyUrl { get; }
        private string SandBoxPaymentUrl { get; }
        private string SandBoxVerifyUrl { get; }
        private string UnVerifiedUrl { get; }
        private string ReFoundUrl { get; }
        private string ReFoundToken { get; }
        public string GateWayUrl { get; set; }
        public string SandBoxGateWayUrl { get; set; }
        public ZarinPalService(IConfiguration configuration)
        {
            var configuration1 = configuration;
            MerchantId = configuration1.GetSection("ZarinPal")["merchant"];
            PaymentUrl = configuration1.GetSection("ZarinPal")["paymentUrl"];
            VerifyUrl = configuration1.GetSection("ZarinPal")["verifyUrl"];
            UnVerifiedUrl = configuration1.GetSection("ZarinPal")["unVerifiedUrl"];
            ReFoundUrl = configuration1.GetSection("ZarinPal")["reFoundUrl"];
            ReFoundToken = configuration1.GetSection("ZarinPal")["reFoundToken"];
            GateWayUrl = configuration1.GetSection("ZarinPal")["StartPay"];
            //
            SandBoxPaymentUrl = configuration1.GetSection("ZarinPal-sandBox")["paymentUrl"];
            SandBoxVerifyUrl = configuration1.GetSection("ZarinPal-sandBox")["verifyUrl"];
            SandBoxGateWayUrl = configuration1.GetSection("ZarinPal-sandBox")["StartPay"];

        }

        public async Task<PaymentResponseData> CreatePaymentRequest(int amount,
            string description,
            string callBackUrl,
            string mobile = null, string email = null)
        {
            var client = new RestClient(PaymentUrl);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            //Zarin pal Amount Type = Rial
            //For Convert Tooman TO Rial Should do amount * 10 
            var body = new PaymentRequest
            {
                Mobile = mobile,
                CallbackUrl = callBackUrl,
                Description = description,
                Email = email,
                Amount = amount * 10,
                MerchantId = MerchantId
            };
            var jsonBody = JsonConvert.SerializeObject(body);
            request.AddJsonBody(jsonBody);
            var response = await client.ExecuteAsync(request);
            var result = JsonConvert.DeserializeObject<PaymentResponse>(response.Content);
            if (result?.Data.Status == 100)
                result.Data.GateWayUrl = GateWayUrl + result.Data.Authority;
            return result?.Data;
        }



        public async Task<FinallyVerificationResponse> CreateVerificationRequest(string authority, int price)
        {
            var client = new RestClient(VerifyUrl);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");

            //Zarin pal Amount Type = Rial
            //For Convert Tooman TO Rial Should do amount * 10 
            var body = new VerificationRequest
            {
                Amount = price * 10,
                MerchantId = MerchantId,
                Authority = authority
            };
            var jsonBody = JsonConvert.SerializeObject(body);
            request.AddJsonBody(jsonBody);
            var response = await client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                var result = JsonConvert.DeserializeObject<VerificationResponse>(response.Content);
                var res = new FinallyVerificationResponse
                {
                    Message = null,
                    CardPan = result?.Data.CardPan,
                    RefId = result.Data.RefId,
                    Status = result.Data.Status
                };

                return res;
            }
            else
            {
                var result = JsonConvert.DeserializeObject<ErrorVerificationResponse>(response.Content);
                var res = new FinallyVerificationResponse
                {
                    Message = result.Errors.Message,
                    CardPan = null,
                    RefId = 0,
                    Status = result.Errors.Code
                };

                return res;
            }
        }



        public async Task<UnVerificationFinallyResponse> GetUnVerificationRequests()
        {
            var client = new RestClient(UnVerifiedUrl);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");

            var body = new UnVerificationRequest()
            {
                MerchantId = MerchantId
            };
            var jsonBody = JsonConvert.SerializeObject(body);
            request.AddJsonBody(jsonBody);
            var response = await client.ExecuteAsync(request);
            var result = JsonConvert.DeserializeObject<UnVerificationResponse>(response.Content);
            return result?.Data;
        }

        public async Task<ReFoundResponse> ReFoundRequest(string authority)
        {
            var client = new RestClient(ReFoundUrl);
            var request = new RestRequest(Method.POST);
            request.AddHeader("authorization", $"Bearer {ReFoundToken}");
            request.AddHeader("Content-Type", "application/json");

            request.AddJsonBody(new ReFoundRequest()
            {
                Authority = authority,
                MerchantId = MerchantId
            });
            var result = await client.ExecuteAsync<ReFoundResponse>(request);
            return result.Data;
        }


        #region SandBox
        public async Task<PaymentResponseData> SandBox_CreatePaymentRequest(int amount,
            string description,
            string callBackUrl,
            string mobile = null, string email = null)
        {
            var client = new RestClient(SandBoxPaymentUrl);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Content-Type", "application/json");
            //Zarin pal Amount Type = Rial
            //For Convert Tooman TO Rial Should do amount * 10 
            var body = new
            {
                MerchantID = "4ced0a1e-XXXX-XXXX-XXXX-3ea3ae8e8897",
                Amount = amount,
                CallbackURL = callBackUrl,
                Description = description
            };
            request.AddJsonBody(body);
            var response = await client.ExecuteAsync<SandBoxPaymentResponse>(request);
            var result = response.Data;

            return new PaymentResponseData()
            {
                Status = result.Status,
                Message = " ",
                Authority = result.Authority,
                Fee = 0,
                GateWayUrl = SandBoxGateWayUrl + result.Authority
            };
        }

        public async Task<FinallyVerificationResponse> SandBox_CreateVerificationRequest(string authority, int price)
        {
            var client = new RestClient(SandBoxVerifyUrl);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");

            //Zarin pal Amount Type = Rial
            //For Convert Tooman TO Rial Should do amount * 10 
            var body = new
            {
                Amount = price,
                MerchantID = "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX",
                Authority = authority
            };
            request.AddJsonBody(body);
            var response = await client.ExecuteAsync<SandBoxVerificationResponse>(request);
            var result = response.Data;

            return new FinallyVerificationResponse()
            {
                RefId = result.RefId,
                Message = " ",
                Status = result.Status
            };
        }

        #endregion
    }
}