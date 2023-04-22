using CoreModule.Domain.Teacher.Events;
using MediatR;

namespace CoreModule.Application.Teacher._EventHandlers;

class AcceptRequestEventHandler : INotificationHandler<AcceptTeacherRequestEvent>
{
    public async Task Handle(AcceptTeacherRequestEvent notification, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }
}

class RejectRequestEventHandler : INotificationHandler<RejectTeacherRequestEvent>
{
    public async Task Handle(RejectTeacherRequestEvent notification, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }
}