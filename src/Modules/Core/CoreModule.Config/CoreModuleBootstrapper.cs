using CoreModule.Application.Category.Create;
using CoreModule.Facade;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CoreModule.Config
{
    public static class CoreModuleBootstrapper
    {
        public static IServiceCollection InitCoreModule(this IServiceCollection services)
        {
            CoreModuleFacadeBootstrapper.RegisterDependency(services);

            services.AddMediatR(typeof(CreateCategoryCommand).Assembly);
            services.
            return services;
        }
    }
}