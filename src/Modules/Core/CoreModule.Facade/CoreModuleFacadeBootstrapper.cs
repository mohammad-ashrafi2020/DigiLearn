using CoreModule.Facade.Category;
using CoreModule.Facade.Course;
using CoreModule.Facade.Orders;
using CoreModule.Facade.Teacher;
using Microsoft.Extensions.DependencyInjection;

namespace CoreModule.Facade;

public class CoreModuleFacadeBootstrapper
{
    public static void RegisterDependency(IServiceCollection services)
    {
        services.AddScoped<ITeacherFacade, TeacherFacade>();
        services.AddScoped<ICourseFacade, CourseFacade>();
        services.AddScoped<ICourseCategoryFacade, CourseCategoryFacade>();
        services.AddScoped<IOrderFacade, OrderFacade>();
    }
}