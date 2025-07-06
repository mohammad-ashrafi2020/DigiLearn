using Common.Application;
using Common.Application.SecurityUtil;
using DigiLearn.WebApi.Infrastructure;
using DigiLearn.WebApi.Infrastructure.JwtUtils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Drawing;
using Microsoft.AspNetCore.Authorization;
using UserModule.Core.Commands.Notifications.Create;
using UserModule.Core.Commands.Notifications.Delete;
using UserModule.Core.Commands.Roles.Create;
using UserModule.Core.Commands.Roles.Edit;
using UserModule.Core.Commands.Users.ChangeAvatar;
using UserModule.Core.Commands.Users.ChangePassword;
using UserModule.Core.Commands.Users.Edit;
using UserModule.Core.Commands.Users.FullEdit;
using UserModule.Core.Commands.Users.Register;
using UserModule.Core.Queries._DTOs;
using UserModule.Core.Services;
using UserModule.Data.Entities.Roles;
using UserModule.Core.Commands.Notifications.DeleteAll;
using UserModule.Core.Commands.Notifications.Seen;
using DigiLearn.WebApi.Models.Auth;
using DigiLearn.WebApi.Models.User;
using DigiLearn.WebApi.Models.User.Notification;
using DigiLearn.WebApi.Infrastructure.Security;

namespace DigiLearn.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ApiController
    {
        private readonly IConfiguration _configuration;
        private readonly IUserFacade _facade;
        private readonly IRoleFacade _roleFacade;
        private readonly INotificationFacade _notificationFacade;

        public UserController(IUserFacade facade, IConfiguration configuration, IRoleFacade roleFacade, INotificationFacade notificationFacade)
        {
            _facade = facade;
            _configuration = configuration;
            _roleFacade = roleFacade;
            _notificationFacade = notificationFacade;
        }

        #region Auth

        [HttpPost("RegisterUser")]
        public async Task<ApiResult<Guid>> Register([FromBody] RegisterUserCommand command)
        {
            return CommandResult<Guid>(await _facade.RegisterUser(command));
        }

        [HttpPost("LoginUser")]
        public async Task<ApiResult<LoginResultDto?>> LoginUser(
            [FromBody] UserLoginCommandViewModel command)
        {
            var user = await _facade.GetUserByPhoneNumber(command.PhoneNumber);
            if (user == null)
            {
                return CommandResult(
                    OperationResult<LoginResultDto>.Error("کاربری با مشخصات وارد شده یافت نشد"));
            }
            if (Sha256Hasher.IsCompare(user.Password, command.Password) == false)
            {
                return CommandResult(
                    OperationResult<LoginResultDto>.Error("کاربری با مشحصات وارد شده یافت نشد"));
            }

            var token = JwtTokenBuilder.BuildToken(user, command.RememberMe, _configuration);
            //JwtTokenBuilder
            return CommandResult<LoginResultDto>(
                OperationResult<LoginResultDto>.Success
                (new LoginResultDto { Token = token }));
        }

        #endregion

        #region User
        [HttpPatch("EditUserProfile")]
        [Authorize]
        public async Task<ApiResult> EditUserProfile(EditUserViewModel command)
        {
            return CommandResult(await _facade.EditUserProfile(new EditUserCommand
            {
                Email = command.Email,
                Family = command.Family,
                Name = command.Name,
                UserId = User.GetUserId(),
            }));
        }

        [HttpPatch("EditUser")]
        [Authorize]
        public async Task<ApiResult> EditUser(FullEditUserViewModel command)
        {
            return CommandResult(await _facade.EditUser(new FullEditUserCommand
            {
                Email = command.Email,
                Family = command.Family,
                Name = command.Name,
                Password = command.Password,
                PhoneNumber = command.PhoneNumber,
                Roles = command.Roles,
                UserId = User.GetUserId()
            }));
        }

        [HttpPatch("ChangeAvatar")]
        [Authorize]
        public async Task<ApiResult> ChangeAvatar(ChangeUserAvatarViewModel command)
        {
            return CommandResult(await _facade.ChangeAvatar(new ChangeUserAvatarCommand
            {
                AvatarFile = command.AvatarFile,
                UserId = User.GetUserId()
            }));
        }

        [HttpPatch("ChangeUserPassword")]
        [Authorize]
        public async Task<ApiResult> ChangePassword(ChangeUserPasswordViewModel command)
        {
            return CommandResult(await _facade.ChangePassword(new ChangeUserPasswordCommand
            {
                CurrentPassword = command.CurrentPassword,
                NewPassword = command.NewPassword,
                UserId = User.GetUserId()
            }));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <example>
        /// نمونه ریکوئست  => api/User/GetUserByPhoneNumber?{phoneNumber}
        /// </example>
        /// <returns></returns>
        [HttpGet("GetUserByPhoneNumber")]
        [Authorize]
        public async Task<ApiResult<UserDto?>> GetUserByPhoneNumber(string phoneNumber)
        {
            return QueryResult(await _facade.GetUserByPhoneNumber(phoneNumber));
        }

        [HttpGet("GetUserById")]
        [Authorize]
        public async Task<ApiResult<UserDto?>> GetUserById()
        {
            return QueryResult(await _facade.GetById(User.GetUserId()));
        }

        [HttpGet("GetUserByFilter")]
        [Authorize]
        [PermissionChecker(UserModule.Data.Entities._Enums.Permissions.مدیریت_کاربران)]
        public async Task<ApiResult<UserFilterResult>> GetUserByFilter(UserFilterParams filterParams)
        {
            return QueryResult(await _facade.GetByFilter(filterParams));
        }
        #endregion

        #region Role

        [HttpPost("CreateRole")]
        [Authorize]
        public async Task<ApiResult> CreateRole(CreateRoleCommand command)
        {
            return CommandResult(await _roleFacade.Create(command));
        }

        [HttpPatch("EditRole")]
        [Authorize]
        public async Task<ApiResult> EditRole(EditRoleCommand command)
        {
            return CommandResult(await _roleFacade.Edit(command));
        }

        [HttpDelete("DeleteRole")]
        [Authorize]
        public async Task<ApiResult> DeleteRole(Guid roleId)
        {
            return CommandResult(await _roleFacade.Delete(roleId));
        }

        [HttpGet("GetRoleById")]
        [Authorize]
        public async Task<ApiResult<Role?>> GetRoleById(Guid roleId)
        {
            return QueryResult(await _roleFacade.GetRoleById(roleId));
        }

        [HttpGet("GetAllRoles")]
        [Authorize]
        public async Task<ApiResult<List<Role>>> GetAllRoles()
        {
            return QueryResult(await _roleFacade.GetAllRoles());
        }
        #endregion

        #region Notification   

        [HttpPost("CreateNotification")]
        public async Task<ApiResult> CreateNotification(CreateNotificationViewModel command)
        {
            return CommandResult(await _notificationFacade.Create(new CreateNotificationCommand
            {
                Text = command.Title,
                Title = command.Title,
                UserId = User.GetUserId()
            }));
        }

        [HttpDelete("DeleteNotification")]
        [Authorize]
        public async Task<ApiResult> DeleteNotification(DeleteNotificationViewModel command)
        {
            return CommandResult(await _notificationFacade.Delete(
                new DeleteNotificationCommand(command.NotificationId, User.GetUserId())));
        }

        [HttpDelete("DeleteAll")]
        [Authorize]
        public async Task<ApiResult> DeleteAllNotification()
        {
            return CommandResult(await _notificationFacade.DeleteAll(
                new DeleteAllNotificationCommand(User.GetUserId())));
        }

        [HttpPatch("SeenNotification")]
        public async Task<ApiResult> SeenNotification(SeenNotificationCommand command)
        {
            return CommandResult(await _notificationFacade.Seen(command));
        }

        [HttpGet("GetNotificationByFilter")]
        public async Task<ApiResult<NotificationFilterResult>> GetNotificationByFilter(
            NotificationFilterParamsViewModel filterParams)
        {
            return QueryResult(await _notificationFacade.GetByFilter(
                new NotificationFilterParams
                {
                    IsSeen = filterParams.IsSeen,
                    PageId = filterParams.PageId,
                    Take = filterParams.Take,
                    UserId = User.GetUserId()
                }));
        }

        #endregion

    }
}
