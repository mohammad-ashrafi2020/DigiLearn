using CommentModule.Domain;
using CommentModule.Services;
using CommentModule.Services.DTOs;
using Common.Application;
using DigiLearn.Web.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DigiLearn.Web.Controllers
{
    public class CommentController : BaseController
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateComment(CreateCommentCommand command)
        {
            command.UserId = User.GetUserId();
            return await AjaxTryCatch(() => _commentService.CreateComment(command));
        }

        [Route("/comment/getByFilter")]
        public async Task<IActionResult> GetComments([FromQuery] Guid entityId, [FromQuery] CommentType commentType)
        {
            var model = await _commentService.GetCommentByFilter(new CommentFilterParams()
            {
                EntityId = entityId,
                CommentType = commentType
            });
            return PartialView("Shared/Comments/_Comments", model);
        }
    }
}
