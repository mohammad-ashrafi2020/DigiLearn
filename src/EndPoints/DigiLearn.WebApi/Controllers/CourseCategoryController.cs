using CoreModule.Application.Category.AddChild;
using CoreModule.Application.Category.Create;
using CoreModule.Application.Category.Edit;
using CoreModule.Application.Course.Edit;
using CoreModule.Facade.Category;
using CoreModule.Query.Category._DTOs;
using DigiLearn.WebApi.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DigiLearn.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseCategoryController : ApiController
    {
        private readonly ICourseCategoryFacade _facade;

        public CourseCategoryController(ICourseCategoryFacade facade)
        {
            _facade = facade;
        }

        #region Commands
        [HttpPost("CreateCourseCategory")]
        [Authorize]
        public async Task<ApiResult> CreateCourseCategory(CreateCategoryCommand command)
        {
            return CommandResult(await _facade.Create(command));
        }
      
        [HttpPatch("EditCourseCategory")]
        [Authorize]
        public async Task<ApiResult> EditCourseCategory(EditCategoryCommand command)
        {
            return CommandResult(await _facade.Edit(command));
        }
      
        [HttpDelete("DeleteCourseCategory")]
        [Authorize]
        public async Task<ApiResult> DeleteCourseCategory(Guid CourseCategoryId)
        {
            return CommandResult(await _facade.Delete(CourseCategoryId));
        }
      
        [HttpPost("AddChildeCourseCategory")]
        [Authorize]
        public async Task<ApiResult> AddChildeCourseCategory(AddChildCategoryCommand command)
        {
            return CommandResult(await _facade.AddChild(command));
        }
        #endregion

        #region Queries
        [HttpGet("GetMainCourseCategories")]
        public async Task<ApiResult<List<CourseCategoryDto>>> GetMainChildeCourseCategories()
        {
            return QueryResult(await _facade.GetMainCategories());
        }
      
        [HttpGet("GetByIdCourseCategory")]
        public async Task<ApiResult<CourseCategoryDto?>> GetByIdChildeCourseCategory(Guid categoryId)
        {
            return QueryResult(await _facade.GetById(categoryId));
        }
      
        [HttpGet("GetChildrenCourseCategory")]
        public async Task<ApiResult<List<CourseCategoryDto>>> GetChildrenCourseCategory(Guid parentId)
        {
            return QueryResult(await _facade.GetChildren(parentId));
        }
        #endregion
    }
}
