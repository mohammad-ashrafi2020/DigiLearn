using System.ComponentModel.DataAnnotations;
using Common.Application;
using DigiLearn.Web.Infrastructure.RazorUtils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserModule.Core.Commands.Users.Register;
using UserModule.Core.Services;

namespace DigiLearn.Web.Pages.Auth;


[BindProperties]
public class RegisterModel : BaseRazor
{
    private readonly IUserFacade _userFacade;

    public RegisterModel(IUserFacade userFacade)
    {
        _userFacade = userFacade;
    }


    [Display(Name = "شماره تلفن")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    public string PhoneNumber { get; set; }

    [Display(Name = "کلمه عبور")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    [MinLength(5, ErrorMessage = "کلمه عبور باید بیشتر از 5 کاراکتر باشد")]
    public string Password { get; set; }

    [Display(Name = "تکرار کلمه عبور")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    [Compare("Password", ErrorMessage = "کلمه عبور صحیح نمی باشد")]
    public string ConfirmPassword { get; set; }
    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPost()
    {
        var result = await _userFacade.RegisterUser(new RegisterUserCommand()
        {
            PhoneNumber = PhoneNumber,
            Password = Password
        });
        if (result.Status == OperationResultStatus.Success)
        {
            result.Message = "ثبت نام با موفقیت انجام شد";
        }
        return RedirectAndShowAlert(result, RedirectToPage("Login"));
    }
}