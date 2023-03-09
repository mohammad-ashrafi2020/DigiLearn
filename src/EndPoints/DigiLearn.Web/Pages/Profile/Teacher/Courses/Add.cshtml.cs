using System.ComponentModel.DataAnnotations;
using Common.Domain.Utils;
using Common.Domain.ValueObjects;
using CoreModule.Application.Course.Create;
using CoreModule.Domain.Course.Enums;
using CoreModule.Facade.Course;
using CoreModule.Facade.Teacher;
using DigiLearn.Web.Infrastructure;
using DigiLearn.Web.Infrastructure.RazorUtils;
using DigiLearn.Web.Infrastructure.Utils.CustomValidation.IFormFile;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DigiLearn.Web.Pages.Profile.Teacher.Courses;


[ServiceFilter(typeof(TeacherActionFilter))]
[BindProperties]
public class AddModel : BaseRazor
{
    private readonly ICourseFacade _courseFacade;
    private readonly ITeacherFacade _teacherFacade;
    public AddModel(ICourseFacade courseFacade, ITeacherFacade teacherFacade)
    {
        _courseFacade = courseFacade;
        _teacherFacade = teacherFacade;
    }


    [Display(Name = "دسته بندی اصلی")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    public Guid CategoryId { get; set; }


    [Display(Name = "زیر دسته بندی")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    public Guid SubCategoryId { get; set; }

    [Display(Name = "عنوان دوره")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    public string Title { get; set; }


    [Display(Name = "عنوان انگلیسی دوره")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    public string Slug { get; set; }


    [Display(Name = "توضیحات")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    [UIHint("Ckeditor4")]
    public string Description { get; set; }


    [Display(Name = "عکس دوره")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    [FileImage(ErrorMessage = "عکس نامعتبر است")]
    public IFormFile ImageFile { get; set; }

    [Display(Name = "ویدئو معرفی دوره")]
    [FileType("mp4", ErrorMessage = "ویدبئو معرفی نامعتبر است")]
    public IFormFile? VideoFile { get; set; }


    [Display(Name = "قیمت (0=رایگان(")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    public int Price { get; set; }

    [Display(Name = "سطح دوره")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    public CourseLevel CourseLevel { get; set; }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPost()
    {
        var teacher = await _teacherFacade.GetByUserId(User.GetUserId());

        var result = await _courseFacade.Create(new CreateCourseCommand()
        {
            Status = CourseActionStatus.Pending,
            TeacherId = teacher!.Id,
            Slug = Slug.ToSlug(),
            Title = Title,
            ImageFile = ImageFile,
            VideoFile = VideoFile,
            CourseLevel = CourseLevel,
            CategoryId = CategoryId,
            Description = Description,
            SeoData = new SeoData(Title, Title, Title, null),
            Price = Price,
            SubCategoryId = SubCategoryId
        });
        return RedirectAndShowAlert(result, RedirectToPage("Index"));
    }
}