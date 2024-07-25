using Microsoft.EntityFrameworkCore;
using TransactionModule.Context.Mapping;
using TransactionModule.Domain;

namespace TransactionModule.Context
{
    public class TransactionContext : DbContext
    {
        public TransactionContext(DbContextOptions<TransactionContext> options) : base(options)
        {

        }

        public DbSet<UserTransaction> UserTransactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserTransactionMapping).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}