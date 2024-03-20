using DigiLearn.Web.Infrastructure;
using DigiLearn.Web.Infrastructure.RazorUtils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserModule.Core.Commands.Users.ChangeAvatar;
using UserModule.Core.Queries._DTOs;
using UserModule.Core.Services;

namespace DigiLearn.Web.Pages.Profile
{
    public class IndexModel : BaseRazor
    {
        private IUserFacade _userFacade;
        private INotificationFacade _notificationFacade;
        public IndexModel(IUserFacade userFacade, INotificationFacade notificationFacade)
        {
            _userFacade = userFacade;
            _notificationFacade = notificationFacade;
        }


        public List<NotificationFilterData> NewNotification { get; set; }
        public UserDto UserDto { get; set; }
        public async Task OnGet()
        {
            UserDto = await _userFacade.GetUserByPhoneNumber(User.GetPhoneNumber());
            var result = await _notificationFacade.GetByFilter(new NotificationFilterParams()
            {
                IsSeen = false,
                PageId = 1,
                Take = 5,
                UserId = UserDto!.Id
            });
            NewNotification = result.Data;
        }

        public async Task<IActionResult> OnPost(IFormFile avatar)
        {
            var res = await _userFacade.ChangeAvatar(new ChangeUserAvatarCommand()
            {
                AvatarFile = avatar,
                UserId = User.GetUserId()
            });

            return RedirectAndShowAlert(res, Redirect("/profile"));
        }

    }
}
