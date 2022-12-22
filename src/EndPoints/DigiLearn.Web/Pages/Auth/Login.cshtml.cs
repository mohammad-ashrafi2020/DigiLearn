using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using Common.Application.SecurityUtil;
using DigiLearn.Web.Infrastructure.RazorUtils;
using Microsoft.IdentityModel.JsonWebTokens;
using UserModule.Core.Services;
using DigiLearn.Web.Infrastructure.JwtUtil;

namespace DigiLearn.Web.Pages.Auth;


[BindProperties]
public class LoginModel : BaseRazor
{
    private IUserFacade _userFacade;
    private IConfiguration _configuration;
    public LoginModel(IUserFacade userFacade, IConfiguration configuration)
    {
        _userFacade = userFacade;
        _configuration = configuration;
    }

    [Display(Name = "شماره تلفن")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    public string PhoneNumber { get; set; }

    [Display(Name = "کلمه عبور")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    [MinLength(5, ErrorMessage = "کلمه عبور باید بیشتر از 5 کاراکتر باشد")]
    public string Password { get; set; }

    public bool IsRememberMe { get; set; }
    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPost()
    {
        var user = await _userFacade.GetUserByPhoneNumber(PhoneNumber);
        if (user == null)
        {
            ErrorAlert("کاربری با مشخصات وارد شده یافت نشد");
            return Page();
        }
        var isComparePassword = Sha256Hasher.IsCompare(user.Password, Password);
        if (isComparePassword == false)
        {
            ErrorAlert("کاربری با مشخصات وارد شده یافت نشد");
            return Page();
        }

        var token = JwtTokenBuilder.BuildToken(user, _configuration);
        if (IsRememberMe)
        {
            HttpContext.Response.Cookies.Append("digi-token", token, new CookieOptions()
            {
                HttpOnly = true,
                Expires = DateTimeOffset.Now.AddDays(30),
                Secure = true
            });
        }
        else
        {
            HttpContext.Response.Cookies.Append("digi-token", token, new CookieOptions()
            {
                HttpOnly = true,
                Secure = true
            });
        }

        return RedirectToPage("../Index");
    }
}