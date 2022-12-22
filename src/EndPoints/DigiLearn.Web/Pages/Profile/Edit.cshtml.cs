using System.ComponentModel.DataAnnotations;
using DigiLearn.Web.Infrastructure;
using DigiLearn.Web.Infrastructure.RazorUtils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserModule.Core.Commands.Users.Edit;
using UserModule.Core.Services;

namespace DigiLearn.Web.Pages.Profile
{
    [BindProperties]
    public class EditModel : BaseRazor
    {
        private IUserFacade _userFacade;

        public EditModel(IUserFacade userFacade)
        {
            _userFacade = userFacade;
        }

        [Display(Name = "نام")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Name { get; set; }

        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "{0} را وارد کنید")]

        public string Family { get; set; }


        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public async Task OnGet()
        {
            var user = await _userFacade.GetUserByPhoneNumber(User.GetPhoneNumber());
            if (user != null)
            {
                Name = user.Name;
                Family = user.Family;
                Email = user.Email;
            }
        }

        public async Task<IActionResult> OnPost()
        {
            var result = await _userFacade.EditUserProfile(new EditUserCommand()
            {
                Name = Name,
                Family = Family,
                Email = Email,
                UserId = User.GetUserId()
            });
            return RedirectAndShowAlert(result, RedirectToPage("Index"));
        }
    }
}
