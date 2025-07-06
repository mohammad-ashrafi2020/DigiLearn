using Common.EventBus.Abstractions;
using Common.EventBus.RabbitMQ;

namespace DigiLearn.WebApi.Infrastructure
{
    public static class RegisterDependencyServices
    {
        public static IServiceCollection RegisterWebDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IEventBus, EventBusRabbitMQ>();

            return services;
        }
    }
}