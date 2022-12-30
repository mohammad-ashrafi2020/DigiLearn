using Common.Application;
using Microsoft.EntityFrameworkCore;
using UserModule.Data;

namespace UserModule.Core.Commands.Notifications.Delete;

public class DeleteNotificationCommandHandler : IBaseCommandHandler<DeleteNotificationCommand>
{
    private readonly UserContext _userContext;

    public DeleteNotificationCommandHandler(UserContext userContext)
    {
        _userContext = userContext;
    }

    public async Task<OperationResult> Handle(DeleteNotificationCommand request, CancellationToken cancellationToken)
    {
        var notification = await _userContext.Notifications
            .FirstOrDefaultAsync(f => f.UserId == request.UserId &&
                                      f.Id == request.NotificationId, cancellationToken: cancellationToken);

        if (notification == null)
        {
            return OperationResult.NotFound();
        }

        _userContext.Notifications.Remove(notification);
        await _userContext.SaveChangesAsync();
        return OperationResult.Success();
    }
}