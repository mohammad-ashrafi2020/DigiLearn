using BlogModule.Services;
using BlogModule.Services.DTOs.Query;
using CommentModule.Domain;
using CommentModule.Services;
using CommentModule.Services.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DigiLearn.Web.Pages.Blog
{
    public class ShowModel : PageModel
    {
        private IBlogService _blogService;
        private ICommentService _commentService;
        public ShowModel(IBlogService blogService, ICommentService commentService)
        {
            _blogService = blogService;
            _commentService = commentService;
        }

        public BlogPostFilterItemDto BlogPost { get; set; }
        public CommentFilterResult CommentFilterResult { get; set; }



        public async Task<IActionResult> OnGet(string slug)
        {
            var article = await _blogService.GetPostBySlug(slug);
            if (article == null)
            {
                return NotFound();
            }
            BlogPost = article;
            CommentFilterResult = await _commentService.GetCommentByFilter(new CommentFilterParams()
            {
                EntityId = article.Id,
                CommentType = CommentType.Article,
            });
            _blogService.AddPostVisit(article.Id);
            return Page();
        }
    }
}
