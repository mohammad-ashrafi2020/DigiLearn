using BlogModule.Services;
using BlogModule.Services.DTOs.Command;
using BlogModule.Services.DTOs.Query;
using DigiLearn.WebApi.Infrastructure;
using DigiLearn.WebApi.Infrastructure.Security;
using DigiLearn.WebApi.Models.Blog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Permissions;

namespace DigiLearn.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ApiController
    {
        private readonly IBlogService _service;

        public BlogController(IBlogService service)
        {
            _service = service;
        }

        #region Blog
        [Authorize]
        [HttpPost("CreatePost")]
        public async Task<ApiResult> CreatePost([FromForm] CreatePostViewModel command)
        {
            return CommandResult(await _service.CreatePost(new CreatePostCommand
            {
                CategoryId = command.CategoryId,
                ImageFile = command.ImageFile,
                Description = command.Description,
                Slug = command.Slug,
                OwnerName = command.OwnerName,
                Title = command.Title,
                UserId = User.GetUserId()
            }));
        }

        [HttpPatch("EditPost")]
        public async Task<ApiResult> EditPost([FromForm] EditPostCommand command)
        {
            return CommandResult(await _service.EditPost(command));
        }

        /// <summary>
        /// این متد کار حذف پست رو انجام میده
        /// </summary>
        /// <param name="postId"></param>
        /// <example>
        /// نمونه ریکوئست  => api/Blog/DeletePost?{id}
        /// </example>
        /// <returns></returns>
        [HttpDelete("DeletePost")]
        public async Task<ApiResult> DeletePost(Guid postId)
        {
            return CommandResult(await _service.DeletePost(postId));
        }

        [HttpGet("GetPostById")]
        public async Task<ApiResult<BlogPostDto?>> GetPostById(Guid postId)
        {
            return QueryResult(await _service.GetPostById(postId));
        }
        [HttpGet("GetPostBySlug")]
        public async Task<ApiResult<BlogPostFilterItemDto?>> GetPostBySlug(string slug)
        {
            return QueryResult(await _service.GetPostBySlug(slug));
        }
        [HttpGet("GetPostsByFilter")]
        public async Task<ApiResult<BlogPostFilterResult>> GetPostsByFilter(
            [FromQuery] BlogPostFilterParams filterParams)
        {
            return QueryResult(await _service.GetPostsByFilter(filterParams));
        }
        #endregion

        //PostCategory
        #region Category
        [HttpPost("CreateCategory")]
        public async Task<ApiResult> CreateCategory
        (CreateBlogCategoryCommand command)
        {
            return CommandResult(await _service.CreateCategory(command));
        }
        [HttpPatch("EditCategory")]
        public async Task<ApiResult> EditCategory
        (EditBlogCategoryCommand command)
        {
            return CommandResult(await _service.EditCategory(command));
        }
        [HttpDelete("DeleteCategory")]
        public async Task<ApiResult> DeleteCategory
        (Guid categoryId)
        {
            return CommandResult(await _service.DeleteCategory(categoryId));
        }
        [HttpGet("GetCategoryById")]
        public async Task<ApiResult<BlogCategoryDto>> GetCategoryById(Guid categoryId)
        {
            return QueryResult(await _service.GetCategoryById(categoryId));
        }
        [HttpGet("GetAllCategories")]
        public async Task<ApiResult<List<BlogCategoryDto>>> GetAllCategories()
        {
            return QueryResult(await _service.GetAllCategories());
        }
        #endregion
    }
}
