using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TicketModule.Data;

namespace TicketModule;

public static class TicketBootstrapper
{
    public static IServiceCollection InitBlogModule(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<TicketContext>(option =>
        {
            option.UseSqlServer(config.GetConnectionString("Ticket_Context"));
        });
        services.AddAutoMapper(typeof(MapperProfile).Assembly);

        return services;
    }
}