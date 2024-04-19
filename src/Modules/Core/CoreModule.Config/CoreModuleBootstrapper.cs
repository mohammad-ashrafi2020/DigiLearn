using CoreModule.Application.Category;
using CoreModule.Application.Category.Create;
using CoreModule.Application.Course;
using CoreModule.Application.Order;
using CoreModule.Application.Teacher;
using CoreModule.Domain.Category.DomainServices;
using CoreModule.Domain.Course.DomainServices;
using CoreModule.Domain.Order.DomainServices;
using CoreModule.Domain.Teacher.DomainServices;
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

            services.AddScoped<ICourseDomainService, CourseDomainService>();
            services.AddScoped<ITeacherDomainService, TeacherDomainService>();
            services.AddScoped<ICategoryDomainService, CategoryDomainService>();
            services.AddScoped<IOrderDomainService, OrderDomainService>();

            return services;
        }
    }
}