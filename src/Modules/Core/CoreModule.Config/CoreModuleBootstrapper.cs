using CoreModule.Application.Category.Create;
using CoreModule.Facade;
using CoreModule.Infrastructure;
using CoreModule.Query;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoreModule.Config
{
    public static class CoreModuleBootstrapper
    {
        public static IServiceCollection InitCoreModule(this IServiceCollection services, IConfiguration configuration)
        {
            CoreModuleFacadeBootstrapper.RegisterDependency(services);
            CoreModuleInfrastructureBootstrapper.RegisterDependency(services, configuration);
            CoreModuleQueryBootstrapper.RegisterDependency(services, configuration);

            services.AddMediatR(typeof(CreateCategoryCommand).Assembly);
            services.AddValidatorsFromAssembly(typeof(CreateCategoryCommand).Assembly);



            return services;
        }
    }
}