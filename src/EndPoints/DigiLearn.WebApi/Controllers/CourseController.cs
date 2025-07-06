using CoreModule.Application.Course.Create;
using CoreModule.Application.Course.Edit;
using CoreModule.Application.Course.Episodes.Add;
using CoreModule.Application.Course.Episodes.Delete;
using CoreModule.Application.Course.Episodes.Edit;
using CoreModule.Application.Course.Sections.AddSection;
using CoreModule.Facade.Course;
using DigiLearn.WebApi.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DigiLearn.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ApiController
    {
        private readonly ICourseFacade _facade;

        public CourseController(ICourseFacade facade)
        {
            _facade = facade;
        }

        [HttpPost("CreateCourse")]
        [Authorize]
        public async Task<ApiResult> CreateCourse(CreateCourseCommand command)
        {
            return CommandResult(await _facade.Create(command));
        }
        
        [HttpPatch("EditCourse")]
        [Authorize]
        public async Task<ApiResult> EditCourse(EditCourseCommand command)
        {
            return CommandResult(await _facade.Edit(command));
        }
        
        [HttpPost("AddCourseSection")]
        [Authorize]
        public async Task<ApiResult> AddCourseSection(AddCourseSectionCommand command)
        {
            return CommandResult(await _facade.AddSection(command));
        }
        
        [HttpPost("AddCourseEpisode")]
        [Authorize]
        public async Task<ApiResult> AddCourseEpisode(AddCourseEpisodeCommand command)
        {
            return CommandResult(await _facade.AddEpisode(command));
        }

        [HttpDelete("DeleteCourseEpisode")]
        [Authorize]
        public async Task<ApiResult> DeleteCourse(DeleteCourseEpisodeCommand command)
        {
            return CommandResult(await _facade.DeleteEpisode(command));
        }
        
        [HttpPatch("EditCourseEpisode")]
        [Authorize]
        public async Task<ApiResult> EditCourseEpisode(EditEpisodeCommand command)
        {
            return CommandResult(await _facade.EditEpisode(command));
        }
        
        [HttpPost("AddStudent")]
        [Authorize]
        public async Task<ApiResult> AddStudent(Guid courseId)
        {
            return CommandResult(await _facade.AddStudent(courseId, User.GetUserId()));
        }
        
        [HttpDelete("DeleteStudent")]
        [Authorize]
        public async Task<ApiResult> DeleteStudent(Guid courseId)
        {
            return CommandResult(await _facade.DeleteStudent(courseId, User.GetUserId()));
        }
    }
}
