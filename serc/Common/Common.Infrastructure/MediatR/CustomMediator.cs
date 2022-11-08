using MediatR;

namespace Common.Infrastructure.MediatR;

public class CustomMediator:Mediator
{
    private readonly Func<IEnumerable<Func<INotification, CancellationToken, Task>>, INotification, CancellationToken, Task> _publish;

    public CustomMediator(ServiceFactory serviceFactory, Func<IEnumerable<Func<INotification, CancellationToken, Task>>, INotification, CancellationToken, Task> publish) : base(serviceFactory)
    {
        _publish = publish;
    }

    protected override Task PublishCore(IEnumerable<Func<INotification, CancellationToken, Task>> allHandlers, INotification notification, CancellationToken cancellationToken)
    {
        return _publish(allHandlers, notification, cancellationToken);
    }
}