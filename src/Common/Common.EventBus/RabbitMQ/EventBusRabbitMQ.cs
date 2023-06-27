using System.Text;
using Common.EventBus.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace Common.EventBus.RabbitMQ;

public class EventBusRabbitMQ : IEventBus
{
    private readonly string _hostName;
    private readonly string _password;
    private readonly string _userName;
    private readonly ILogger<EventBusRabbitMQ> _logger;

    public EventBusRabbitMQ(IConfiguration configuration, ILogger<EventBusRabbitMQ> logger)
    {
        _logger = logger;
        _hostName = configuration.GetSection("RabbitMQ")["HostName"];
        _userName = configuration.GetSection("RabbitMQ")["UserName"];
        _password = configuration.GetSection("RabbitMQ")["Password"];
    }

    private IConnection _connection;
    public IConnection Connection
    {
        get
        {
            CreateRabbitMqConnection();
            return _connection;
        }
    }

    public void Publish(IntegrationEvent @event, string? queueName, string exchange = "", string exchangeType = ExchangeType.Direct, string routeKey = "")
    {
        CreateRabbitMqConnection();
        using var channel = Connection.CreateModel();

        if (string.IsNullOrWhiteSpace(routeKey))
        {
            routeKey = queueName ?? "";
        }
        if (string.IsNullOrWhiteSpace(queueName) == false)
        {
            channel.QueueDeclare(queue: queueName,
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);
            if (exchangeType == ExchangeType.Direct && exchange != "")
            {
                channel.QueueBind(queueName, exchange, queueName);
            }
        }

        if (string.IsNullOrWhiteSpace(exchange) == false)
        {
            channel.ExchangeDeclare(exchange, exchangeType, true, false);
        }

        var json = JsonConvert.SerializeObject(@event);
        var body = Encoding.UTF8.GetBytes(json);

        var properties = channel.CreateBasicProperties();
        properties.Persistent = true;

        channel.BasicPublish(
            exchange: exchange,
            routingKey: routeKey,
            basicProperties: properties,
            body: body);
    }

    private void CreateRabbitMqConnection()
    {

        try
        {
            if (_connection != null)
                return;

            var factory = new ConnectionFactory()
            {
                UserName = _userName,
                Password = _password,
                HostName = _hostName
            };
            _connection = factory.CreateConnection();

        }
        catch (Exception e)
        {
            _logger.LogCritical(e.Message, e);
            throw;
        }
    }
}