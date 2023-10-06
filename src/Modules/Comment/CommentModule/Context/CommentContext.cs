using CommentModule.Domain;
using Microsoft.EntityFrameworkCore;

namespace CommentModule.Context;

class CommentContext : DbContext
{
    public CommentContext(DbContextOptions<CommentContext> options) : base(options)
    {

    }


    public DbSet<Comment> Comments { get; set; }
    public DbSet<User> Users { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("dbo");
        base.OnModelCreating(modelBuilder);
    }
}