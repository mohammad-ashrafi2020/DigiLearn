using System.ComponentModel.DataAnnotations;
using CoreModule.Application.Teacher.Register;
using CoreModule.Domain.Teacher.Enums;
using CoreModule.Facade.Teacher;
using DigiLearn.Web.Infrastructure;
using DigiLearn.Web.Infrastructure.RazorUtils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DigiLearn.Web.Pages.Profile;

[BindProperties]
public class RegisterTeacherModel : BaseRazor
{
    private ITeacherFacade _teacherFacade;

    public RegisterTeacherModel(ITeacherFacade teacherFacade)
    {
        _teacherFacade = teacherFacade;
    }

    [Display(Name = "رزومه (پسوند بهتر است pdf باشد)")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    public IFormFile CvFile { get; set; }

    [Display(Name = "نام کاربری")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    public string UserName { get; set; }
    public async Task<IActionResult> OnGet()
    {
        var teacher = await _teacherFacade.GetByUserId(User.GetUserId());
        if (teacher != null)
        {
            if (teacher.Status is TeacherStatus.Active or TeacherStatus.Inactive)
            {
                ErrorAlert("شما قبلا ثبت نام کرده اید");
            }
            else
            {
                SuccessAlert("درخواست شما درحال برسی است");
            }
            return RedirectToPage("Index");
        }
        return Page();
    }


    public async Task<IActionResult> OnPost()
    {
        var result = await _teacherFacade.Register(new RegisterTeacherCommand()
        {
            UserId = User.GetUserId(),
            CvFile = CvFile,
            UserName = UserName
        });


        return RedirectAndShowAlert(result, RedirectToPage("Index"));
    }
}