using System.Text;
using Common.EventBus.Abstractions;
using Common.EventBus.Events;
using CoreModule.Infrastructure.Persistent;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace CoreModule.Infrastructure.EventHandlers;

public class UserChangeAvatarEventHandler : BackgroundService
{
    private readonly IEventBus _eventBus;
    private string _queueName = "coreModuleUserChangeAvatar";
    private readonly ILogger<UserChangeAvatarEventHandler> _logger;
    private readonly IServiceScopeFactory _serviceFactory;
    public UserChangeAvatarEventHandler(IEventBus eventBus, ILogger<UserChangeAvatarEventHandler> logger, IServiceScopeFactory serviceFactory)
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

        var context = serviceScope.ServiceProvider.GetRequiredService<CoreModuleEfContext>();

        var model = connection.CreateModel();
        model.ExchangeDeclare(Exchanges.UserTopicExchange, ExchangeType.Topic, true, false, null);
        model.QueueDeclare(_queueName, true, false, false, null);
        model.QueueBind(_queueName, Exchanges.UserTopicExchange, "user.changeAvatar", null);

        var consumer = new EventingBasicConsumer(model);
        consumer.Received += async (sender, args) =>
        {
            try
            {
                var userJson = Encoding.UTF8.GetString(args.Body.ToArray());
                var user = JsonConvert.DeserializeObject<UserChangeAvatar>(userJson);

                var oldUser = await context.Users.FirstOrDefaultAsync(f => f.Id == user.UserId, stoppingToken);
                if (oldUser == null)
                {
                    return;
                }

                oldUser.Avatar = user.Avatar;
                context.Update(oldUser);
                await context.SaveChangesAsync(stoppingToken);
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