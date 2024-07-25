using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TransactionModule.Context;
using TransactionModule.Services;

namespace TransactionModule
{
    public class TransactionBootstrapper
    {
        public static void Init(IServiceCollection service, string connectionString)
        {
            service.AddDbContext<TransactionContext>(option =>
            {
                option.UseSqlServer(connectionString);
            });
            service.AddTransient<IUserTransactionService, UserTransactionService>();
        }
    }
}
