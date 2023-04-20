using System.ComponentModel.DataAnnotations;
using Common.Application;
using Common.Domain.ValueObjects;
using CoreModule.Application.Course.Edit;
using CoreModule.Domain.Course.Enums;
using CoreModule.Facade.Course;
using DigiLearn.Web.Infrastructure.RazorUtils;
using DigiLearn.Web.Infrastructure.Utils.CustomValidation.IFormFile;
using DigiLearn.Web.Infrastructure.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DigiLearn.Web.Areas.Admin.Pages.Courses
{

    [BindProperties]
    public class EditModel : BaseRazor
    {
        private readonly ICourseFacade _courseFacade;

        public EditModel(ICourseFacade courseFacade)
        {
            _courseFacade = courseFacade;
        }


        public Guid CategoryId { get; set; }
        public Guid SubCategoryId { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Title { get; set; }

        [Display(Name = "عنوان انگلیسی")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Slug { get; set; }

        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [UIHint("Ckeditor4")]
        public string Description { get; set; }


        [Display(Name = "عکس")]
        [FileImage(ErrorMessage = "عکس نامعتبر است")]
        public IFormFile? ImageFile { get; set; }

        [Display(Name = "ویدئو معرفی")]
        [FileType("mp4", ErrorMessage = "ویدئو معرفی نامعتبر است")]
        public IFormFile? VideoFile { get; set; }


        [Display(Name = "قیمت")]
        public int Price { get; set; }
        public SeoDataViewModel SeoData { get; set; }



        [Display(Name = "سطح دوره")]
        public CourseLevel CourseLevel { get; set; }


        [Display(Name = "وضعیت دوره")]
        public CourseStatus CourseStatus { get; set; }


        [Display(Name = "وضعیت")]
        public CourseActionStatus ActionStatus { get; set; }

        public async Task<IActionResult> OnGet(Guid courseId)
        {
            var course = await _courseFacade.GetCourseById(courseId);


            if (course == null)
                return RedirectToPage("Index");


            CategoryId = course.CategoryId;
            SubCategoryId = course.SubCategoryId;
            Title = course.Title;
            Slug = course.Slug;
            Description = course.Description;
            SeoData = SeoDataViewModel.ConvertToViewModel(course.SeoData);
            CourseLevel = course.CourseLevel;
            CourseStatus = course.CourseStatus;
            ActionStatus = course.Status;

            return Page();
        }

        public async Task<IActionResult> OnPost(Guid courseId)
        {
            var result = await _courseFacade.Edit(new EditCourseCommand
            {
                CourseId = courseId,
                CategoryId = CategoryId,
                SubCategoryId = SubCategoryId,
                Title = Title,
                Slug = Slug,
                Description = Description,
                ImageFile = ImageFile,
                VideoFile = VideoFile,
                Price = Price,
                SeoData = SeoData.Map(),
                CourseLevel = CourseLevel,
                CourseStatus = CourseStatus,
                CourseActionStatus = ActionStatus
            });
            return RedirectAndShowAlert(result, RedirectToPage("Index"));
        }
    }
}
