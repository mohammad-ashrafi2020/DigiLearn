using Common.Application;

namespace UserModule.Core.Commands.Notifications.DeleteAll;

public record DeleteAllNotificationCommand(Guid UserId) : IBaseCommand;