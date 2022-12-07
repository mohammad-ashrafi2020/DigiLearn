using System.Linq.Expressions;
using Common.Domain;
using Common.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Common.Infrastructure.Repository;

public  class BaseRepository<T, TContext> : IBaseRepository<T>
    where TContext : DbContext where T : BaseEntity
{
    protected readonly TContext Context;
    public BaseRepository(TContext context)
    {
        Context = context;
    }
    public async Task<T?> GetAsync(Guid id)
    {
        return await Context.Set<T>().FirstOrDefaultAsync(t => t.Id.Equals(id)); ;
    }
    public async Task<T?> GetTracking(Guid id)
    {
        return await Context.Set<T>().AsTracking().FirstOrDefaultAsync(t => t.Id.Equals(id));
    }
    public void Add(T entity)
    {
        Context.Set<T>().Add(entity);
    }
    public async Task AddAsync(T entity)
    {
        await Context.Set<T>().AddAsync(entity);
    }
    public async Task AddRange(ICollection<T> entities)
    {
        await Context.Set<T>().AddRangeAsync(entities);
    }
    public void Update(T entity)
    {
        Context.Update(entity);
    }
    public async Task<int> Save()
    {
        return await Context.SaveChangesAsync();
    }

    public void SaveSync()
    {
        Context.SaveChanges();
    }

    public async Task<bool> ExistsAsync(Expression<Func<T, bool>> expression)
    {
        return await Context.Set<T>().AnyAsync(expression);
    }
    public bool Exists(Expression<Func<T, bool>> expression)
    {
        return Context.Set<T>().Any(expression);
    }
    public T? Get(Guid id)
    {
        return Context.Set<T>().FirstOrDefault(t => t.Id.Equals(id)); ;
    }
}