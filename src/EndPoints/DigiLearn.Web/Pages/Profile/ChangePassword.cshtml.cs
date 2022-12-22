using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using DigiLearn.Web.Infrastructure;
using DigiLearn.Web.Infrastructure.RazorUtils;
using UserModule.Core.Commands.Users.ChangePassword;
using UserModule.Core.Services;

namespace DigiLearn.Web.Pages.Profile
{
    [BindProperties]
    public class ChangePasswordModel : BaseRazor
    {
        private IUserFacade _userFacade;

        public ChangePasswordModel(IUserFacade userFacade)
        {
            _userFacade = userFacade;
        }

        [Display(Name = "کلمه عبور فعلی")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }

        [Display(Name = "کلمه عبور جدید")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [DataType(DataType.Password)]

        public string NewPassword { get; set; }


        [Display(Name = "تکرار کلمه عبور جدید")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [Compare("NewPassword", ErrorMessage = "کلمه های عبور یکسان نیستند")]
        [DataType(DataType.Password)]
        public string ConfirmNewPassword { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            var result = await _userFacade.ChangePassword(new ChangeUserPasswordCommand()
            {
                CurrentPassword = CurrentPassword,
                NewPassword = NewPassword,
                UserId = User.GetUserId()
            });
            return RedirectAndShowAlert(result, RedirectToPage("Index"));

        }
    }
}
