using DigiLearn.Web.Infrastructure.JwtUtil;
using DigiLearn.Web.Infrastructure.RazorUtils;

namespace DigiLearn.Web.Infrastructure;

public static class RegisterDependencyServices
{
    public static IServiceCollection RegisterApiServices(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();

        services.AddScoped<HttpClientAuthorizationDelegatingHandler>();
        services.AddTransient<IRenderViewToString, RenderViewToString>();

        services.AddAutoMapper(typeof(RegisterDependencyServices).Assembly);

        return services;
    }
}