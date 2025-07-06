using Common.Application;

namespace DigiLearn.WebApi.Models.User
{
    public class EditUserViewModel
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public string? Email { get; set; }
    }
    public class FullEditUserViewModel
    {
        public string? Name { get; set; }
        public string? Family { get; set; }
        public string? Email { get; set; }
        public string PhoneNumber { get; set; }
        public string? Password { get; set; }
        public List<Guid> Roles { get; set; }
    }
    public class ChangeUserAvatarViewModel
    {
        public IFormFile AvatarFile { get; set; }
    }
    public class ChangeUserPasswordViewModel
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
