using CommentModule.Context;
using CommentModule.EventHandlers;
using CommentModule.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CommentModule;

public static class CommentBootstrapper
{
    public static IServiceCollection InitCommentModule(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<CommentContext>(option =>
        {
            option.UseSqlServer(config.GetConnectionString("Comment_Context"));
        });
        services.AddScoped<ICommentService, CommentService>();
        services.AddHostedService<UserRegisteredEventHandler>();
        services.AddHostedService<UserEditedEventHandler>();
        services.AddHostedService<UserChangeAvatarEventHandler>();
        services.AddAutoMapper(typeof(MapperProfile).Assembly);

        return services;
    }
}