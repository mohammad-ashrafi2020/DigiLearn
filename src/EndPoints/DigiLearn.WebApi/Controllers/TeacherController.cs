using CoreModule.Application.Teacher.AcceptRequest;
using CoreModule.Application.Teacher.Register;
using CoreModule.Application.Teacher.RejectRequest;
using CoreModule.Facade.Teacher;
using CoreModule.Query.Teacher._DTOs;
using DigiLearn.WebApi.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DigiLearn.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ApiController
    {
        private readonly ITeacherFacade _facade;

        public TeacherController(ITeacherFacade facade)
        {
            _facade = facade;
        }

        [HttpPost("RegisterTeacher")]
        public async Task<ApiResult> RegisterTeacher(RegisterTeacherCommand command)
        {
            return CommandResult(await _facade.Register(command));
        }
        
        [HttpPost("AcceptTeacherRequest")]
        [Authorize]
        public async Task<ApiResult> AcceptTeacherRequest(AcceptTeacherRequestCommand command)
        {
            return CommandResult(await _facade.AcceptRequest(command));
        }
        
        [HttpDelete("RejectTeacherRequest")]
        [Authorize]
        public async Task<ApiResult> RejectTeacherRequest(RejectTeacherRequestCommand command)
        {
            return CommandResult(await _facade.RejectRequest(command));
        }
        
        [HttpPatch("ToggleStatusTeacher")]
        [Authorize]
        public async Task<ApiResult> ToggleStatusTeacher(Guid teacherId)
        {
            return CommandResult(await _facade.ToggleStatus(teacherId));
        }

        #region Queries
        
        [HttpGet("GetTeacherById")]
        [Authorize]
        public async Task<ApiResult<TeacherDto?>> GetTeacherById(Guid id)
        {
            return QueryResult(await _facade.GetById(id));
        }
        
        [HttpGet("GetTeacherByUserId")]
        [Authorize]
        public async Task<ApiResult<TeacherDto?>> GetTeacherByUserId()
        {
            return QueryResult(await _facade.GetByUserId(User.GetUserId()));
        }
        
        [HttpGet("GetTeacherList")]
        [Authorize]
        public async Task<ApiResult<List<TeacherDto>>> GetTeacherList()
        {
            return QueryResult(await _facade.GetList());
        }
        
        #endregion
    }
}
