using RabbitMQ.Client;

namespace Common.EventBus.Abstractions;

public interface IEventBus
{
    public IConnection Connection { get; }
    void Publish(IntegrationEvent @event, string? queueName = null, string exchange = "", string exchangeType = ExchangeType.Direct, string routeKey = "");
}