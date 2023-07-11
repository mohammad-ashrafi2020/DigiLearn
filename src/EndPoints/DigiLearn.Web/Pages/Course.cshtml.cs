using CoreModule.Domain.Course.Models;
using CoreModule.Facade.Course;
using CoreModule.Query.Course._DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DigiLearn.Web.Pages
{
    public class CourseModel : PageModel
    {
        private readonly ICourseFacade _courseFacade;

        public CourseModel(ICourseFacade courseFacade)
        {
            _courseFacade = courseFacade;
        }

        public CourseDto Course { get; set; }
        public async Task<IActionResult> OnGet(string slug)
        {
            var course = await _courseFacade.GetCourseBySlug(slug);
            if (course == null)
            {
                return NotFound();
            }

            Course = course;
            return Page();
        }
    }
}
