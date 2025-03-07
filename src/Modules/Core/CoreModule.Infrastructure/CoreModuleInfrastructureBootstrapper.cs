using Common.EventBus.Events;
using CoreModule.Domain.Category.Repository;
using CoreModule.Domain.Course.Repository;
using CoreModule.Domain.HelperEntities.Repositories;
using CoreModule.Domain.Order.Repositories;
using CoreModule.Domain.Teacher.Repository;
using CoreModule.Infrastructure.EventHandlers;
using CoreModule.Infrastructure.Persistent;
using CoreModule.Infrastructure.Persistent.Category;
using CoreModule.Infrastructure.Persistent.Course;
using CoreModule.Infrastructure.Persistent.HelperEntities.Repositories;
using CoreModule.Infrastructure.Persistent.Order;
using CoreModule.Infrastructure.Persistent.Teacher;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoreModule.Infrastructure;

public class CoreModuleInfrastructureBootstrapper
{
    public static void RegisterDependency(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ICourseRepository, CourseRepository>();
        services.AddScoped<ICourseCategoryRepository, CourseCategoryRepository>();
        services.AddScoped<ITeacherRepository, TeacherRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<ICourseStudentRepository, CourseStudentRepository>();

        services.AddHostedService<UserRegisteredEventHandler>();
        services.AddHostedService<UserEditedEventHandler>();
        services.AddHostedService<UserChangeAvatarEventHandler>();

        services.AddDbContext<CoreModuleEfContext>(option =>
        {
            option.UseSqlServer(configuration.GetConnectionString("CoreModule_Context"));
        });
    }
}