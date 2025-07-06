using Common.Application;
using Common.Query.Filter;

namespace DigiLearn.WebApi.Models.User.Notification
{
    public class CreateNotificationViewModel
    {
        public string Text { get; set; }
        public string Title { get; set; }
    }
    public record DeleteNotificationViewModel(Guid NotificationId);
    public class NotificationFilterParamsViewModel : BaseFilterParam
    {
        public bool? IsSeen { get; set; }
    }
}
