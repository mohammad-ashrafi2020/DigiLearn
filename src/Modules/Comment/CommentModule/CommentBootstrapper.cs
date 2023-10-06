using CommentModule.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CommentModule;

public static class CommentBootstrapper
{
    public static IServiceCollection InitBlogModule(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<CommentContext>(option =>
        {
            option.UseSqlServer(config.GetConnectionString("Comment_Context"));
        });

        services.AddAutoMapper(typeof(MapperProfile).Assembly);

        return services;
    }
}