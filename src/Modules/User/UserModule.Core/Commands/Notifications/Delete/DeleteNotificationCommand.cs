using Common.Application;
using MediatR;

namespace UserModule.Core.Commands.Notifications.Delete;

public record DeleteNotificationCommand(Guid NotificationId, Guid UserId) : IBaseCommand;