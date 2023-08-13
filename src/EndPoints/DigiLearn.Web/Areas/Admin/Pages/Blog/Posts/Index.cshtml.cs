using BlogModule.Services;
using BlogModule.Services.DTOs.Query;
using DigiLearn.Web.Infrastructure.RazorUtils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DigiLearn.Web.Areas.Admin.Pages.Blog.Posts
{
    public class IndexModel : BaseRazorFilter<BlogPostFilterParams>
    {
        private IBlogService _blogService;

        public IndexModel(IBlogService blogService)
        {
            _blogService = blogService;
        }


        public List<BlogCategoryDto> Categories { get; set; }
        public BlogPostFilterResult FilterResult { get; set; }
        public async Task OnGet()
        {
            Categories = await _blogService.GetAllCategories();
            FilterResult = await _blogService.GetPostsByFilter(FilterParams);
        }
    }
}
