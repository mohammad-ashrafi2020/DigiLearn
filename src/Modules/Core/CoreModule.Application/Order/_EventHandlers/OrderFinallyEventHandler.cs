using Common.EventBus.Abstractions;
using Common.EventBus.Events;
using CoreModule.Domain.Order.Events;
using MediatR;
using RabbitMQ.Client;

namespace CoreModule.Application.Order._EventHandlers;

public class OrderFinallyEventHandler : INotificationHandler<OrderFinallyEvent>
{
    private readonly IEventBus _eventBus;

    public OrderFinallyEventHandler(IEventBus eventBus)
    {
        _eventBus = eventBus;
    }

    public async Task Handle(OrderFinallyEvent notification, CancellationToken cancellationToken)
    {
        _eventBus.Publish(new NewNotificationIntegrationEvent()
        {
            Message = "فاکتور شما با موفقیت پرداخت شد",
            Title = "پرداخت موفق",
            UserId = notification.UserId
        }, null, Exchanges.NotificationExchange, ExchangeType.Fanout);
        await Task.CompletedTask;
    }
}