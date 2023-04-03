using CoreModule.Facade.Category;
using CoreModule.Query.Category._DTOs;
using DigiLearn.Web.Infrastructure.RazorUtils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DigiLearn.Web.Areas.Admin.Pages.Courses.Categories
{
    public class IndexModel : BaseRazor
    {
        private readonly ICourseCategoryFacade _categoryFacade;

        public IndexModel(ICourseCategoryFacade categoryFacade)
        {
            _categoryFacade = categoryFacade;
        }

        public List<CourseCategoryDto> Categories { get; set; }
        public async Task OnGet()
        {
            Categories = await _categoryFacade.GetMainCategories();
        }

        public async Task<IActionResult> OnPostDelete(Guid id)
        {
            return await AjaxTryCatch(() => _categoryFacade.Delete(id));
        }
    }
}
