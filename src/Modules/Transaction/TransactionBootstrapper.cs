using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TransactionModule.Context;
using TransactionModule.Services;
using TransactionModule.Services.ZarinPal;

namespace TransactionModule
{
    public static class TransactionBootstrapper
    {
        public static IServiceCollection InitTransactionModule(this IServiceCollection service, IConfiguration config)
        {
            service.AddDbContext<TransactionContext>(option =>
            {
                option.UseSqlServer(config.GetConnectionString("transaction_Context"));
            });
            service.AddTransient<IUserTransactionService, UserTransactionService>();
            service.AddTransient<IZarinPalService, ZarinPalService>();
            return service;
        }
    }
}
