using Common.Application;
using Microsoft.EntityFrameworkCore;
using UserModule.Data;

namespace UserModule.Core.Commands.Notifications.Seen;

public record SeenNotificationCommand(Guid NotificationId) : IBaseCommand
{

}
public class SeenNotificationCommandHandler : IBaseCommandHandler<SeenNotificationCommand>
{
    private readonly UserContext _context;

    public SeenNotificationCommandHandler(UserContext context)
    {
        _context = context;
    }

    public async Task<OperationResult> Handle(SeenNotificationCommand request, CancellationToken cancellationToken)
    {
        var notification = await _context.Notifications
            .FirstOrDefaultAsync(f => f.Id == request.NotificationId && f.IsSeen == false, cancellationToken);

        if (notification == null)
        {
            return OperationResult.NotFound();
        }

        notification.IsSeen = true;
        _context.Update(notification);
        await _context.SaveChangesAsync(cancellationToken);
        return OperationResult.Success();
    }
}