namespace DigiLearn.WebApi.Models.Auth
{
    public class UserLoginCommandViewModel
    {
        public required string PhoneNumber { get; set; }
        public required string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
