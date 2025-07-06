using BlogModule.Services.DTOs.Command;
using BlogModule.Services.DTOs.Query;
using CommentModule.Services;
using CommentModule.Services.DTOs;
using DigiLearn.WebApi.Infrastructure;
using DigiLearn.WebApi.Models.Comment;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DigiLearn.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ApiController
    {
        private readonly ICommentService _service;

        public CommentController(ICommentService service)
        {
            _service = service;
        }


        [HttpPost("CreateComment")]
        public async Task<ApiResult> CreateComment(CreateCommentViewModel command)
        {
            return CommandResult(await _service.CreateComment(new CreateCommentCommand
            {
                CommentType = command.CommentType,
                ParentId = command.ParentId,
                EntityId = command.EntityId,
                Text = command.Text,
                UserId = User.GetUserId(),
            }));
        }

        [HttpDelete("DeleteComment")]
        public async Task<ApiResult> DeleteComment(Guid commentId)
        {
            return CommandResult(await _service.DeleteComment(commentId));
        }

        [HttpGet("GetCommentById")]
        public async Task<ApiResult<CommentDto?>> GetCommentById(Guid commentId)
        {
            return QueryResult(await _service.GetCommentById(commentId));
        }
        [HttpGet("GetCommentByFilter")]
        public async Task<ApiResult<CommentFilterResult>> GetCommentByFilter
            ([FromQuery] CommentFilterParams filterParams)
        {
            return QueryResult(await _service.GetCommentByFilter(filterParams));
        }
        [HttpGet("GetAllComments")]
        public async Task<ApiResult<AllCommentFilterResult>> GetAllComments
            ([FromQuery] CommentFilterParams filterParams)
        {
            return QueryResult(await _service.GetAllComments(filterParams));
        }
    }
}
