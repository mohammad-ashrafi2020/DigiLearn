using DigiLearn.Web.Infrastructure;
using DigiLearn.Web.Infrastructure.RazorUtils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserModule.Core.Commands.Notifications.Delete;
using UserModule.Core.Commands.Notifications.DeleteAll;
using UserModule.Core.Commands.Notifications.Seen;
using UserModule.Core.Queries._DTOs;
using UserModule.Core.Services;

namespace DigiLearn.Web.Pages.Profile
{
    public class NotificationsModel : BaseRazorFilter<NotificationFilterParams>
    {
        private INotificationFacade _notificationFacade;

        public NotificationsModel(INotificationFacade notificationFacade)
        {
            _notificationFacade = notificationFacade;
        }

        public NotificationFilterResult FilterResult { get; set; }
        public async Task OnGet()
        {
            FilterResult = await _notificationFacade.GetByFilter(new NotificationFilterParams()
            {
                IsSeen = null,
                PageId = FilterParams.PageId,
                Take = 6,
                UserId = User.GetUserId()
            });
        }

        public async Task<IActionResult> OnPostSeenNotification(Guid notificationId)
        {
            var result = await _notificationFacade.Seen(new SeenNotificationCommand(notificationId));
            return RedirectAndShowAlert(result, RedirectToPage("Notifications"));
        }
        public async Task<IActionResult> OnPostDeleteAll()
        {
            return await AjaxTryCatch(() => _notificationFacade.DeleteAll(new DeleteAllNotificationCommand(User.GetUserId())));
        }
        public async Task<IActionResult> OnPostDeleteNotification(Guid id)
        {
            return await AjaxTryCatch(() => _notificationFacade.Delete(new DeleteNotificationCommand(id, User.GetUserId())));
        }
    }
}
