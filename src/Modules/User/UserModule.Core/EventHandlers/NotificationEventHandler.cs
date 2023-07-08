using System.Text;
using Common.EventBus.Abstractions;
using Common.EventBus.Events;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using UserModule.Core.Commands.Notifications.Create;
using UserModule.Core.Services;

namespace UserModule.Core.EventHandlers;

public class NotificationEventHandler : BackgroundService
{
    private readonly IEventBus _eventBus;
    private string _queueName = "userNotificationHandler";
    private readonly ILogger<NotificationEventHandler> _logger;
    private readonly IServiceScopeFactory _serviceFactory;
    public NotificationEventHandler(IEventBus eventBus, ILogger<NotificationEventHandler> logger, IServiceScopeFactory serviceFactory)
    {
        _eventBus = eventBus;
        _logger = logger;
        _serviceFactory = serviceFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
        var connection = _eventBus.Connection;
        var serviceScope = _serviceFactory.CreateScope();

        var notificationFacade = serviceScope.ServiceProvider.GetRequiredService<INotificationFacade>();

        var model = connection.CreateModel();
        model.ExchangeDeclare(Exchanges.NotificationExchange, ExchangeType.Fanout, true, false, null);
        model.QueueDeclare(_queueName, true, false, false, null);
        model.QueueBind(_queueName, Exchanges.NotificationExchange, "", null);

        var consumer = new EventingBasicConsumer(model);
        consumer.Received += async (sender, args) =>
        {
            try
            {
                var eventJson = Encoding.UTF8.GetString(args.Body.ToArray());
                var notification = JsonConvert.DeserializeObject<NewNotificationIntegrationEvent>(eventJson);

                await notificationFacade.Create(new CreateNotificationCommand()
                {
                    Title = notification.Title,
                    Text = notification.Message,
                    UserId = notification.UserId
                });
                model.BasicAck(args.DeliveryTag, false);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }
        };
        model.BasicConsume(consumer, _queueName, false);
    }
}