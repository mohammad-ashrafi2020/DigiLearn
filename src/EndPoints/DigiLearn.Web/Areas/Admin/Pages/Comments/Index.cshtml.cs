using AngleSharp.Dom;
using CommentModule.Services;
using CommentModule.Services.DTOs;
using Common.Application.DateUtil;
using Common.Query.Filter;
using DigiLearn.Web.Infrastructure.RazorUtils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DigiLearn.Web.Areas.Admin.Pages.Comments
{
    public class IndexModel : BaseRazorFilter<CommentFilterParams>
    {
        private readonly ICommentService _commentService;

        public IndexModel(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public AllCommentFilterResult FilterResult { get; set; }
        public async Task OnGet(string stDate, string enDate)
        {
            if (string.IsNullOrWhiteSpace(stDate) == false)
            {
                FilterParams.StartDate = stDate.ToMiladi();
            }
            if (string.IsNullOrWhiteSpace(enDate) == false)
            {
                FilterParams.EndDate = enDate.ToMiladi();
            }
            FilterResult = await _commentService.GetAllComments(FilterParams);
        }

        public async Task<IActionResult> OnPostDelete(Guid id)
        {
            return await AjaxTryCatch(() => _commentService.DeleteComment(id));
        }
    }
}
