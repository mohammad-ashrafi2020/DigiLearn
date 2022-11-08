using Common.Application.Validation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Common.Application
{
    public static class CommonBootstrapper
    {
        public static IServiceCollection RegisterCommonApplication(this IServiceCollection service)
        {
            service.AddTransient(typeof(IPipelineBehavior<,>), typeof(CommandValidationBehavior<,>));

            return service;
        }
    }
}