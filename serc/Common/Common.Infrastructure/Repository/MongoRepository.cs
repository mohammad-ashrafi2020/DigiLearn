using System.Linq.Expressions;
using Common.Domain;
using Common.Domain.Repository;
using MongoDB.Driver;

namespace Common.Infrastructure.Repository;

public class MongoRepository<TEntity, TContext> : IMongoRepository<TEntity> where TEntity : BaseEntity where TContext : BaseMongoContext
{
    protected readonly IMongoCollection<TEntity> Collection;
    public MongoRepository(TContext context)
    {
        var dataBase = context.GetDataBase();
        Collection = dataBase.GetCollection<TEntity>(GenerateCollectionName(typeof(TEntity).Name));
    }
    public async Task Delete(Guid id)
    {
        await Collection.DeleteOneAsync(f => f.Id == id);
    }
    public async Task DeleteRange(FilterDefinition<TEntity> filter)
    {
        await Collection.DeleteManyAsync(filter);
    }
    public async Task<List<TEntity>> GetAll()
    {
        var res = await Collection.FindAsync(r => true);
        return res.ToList();
    }
    public async Task<TEntity?> GetById(Guid id)
    {
        var res = await Collection.FindAsync(f => f.Id == id);
        return res.FirstOrDefault();
    }
    public async Task Insert(TEntity entity)
    {
        await Collection.InsertOneAsync(entity);
    }
    public async Task Update(TEntity entity)
    {
        await Collection.ReplaceOneAsync(f => f.Id == entity.Id, entity);
    }

    public async Task<bool> IsExist(Expression<Func<TEntity, bool>> expression)
    {
        var entity = await Collection.FindAsync(expression);
        return entity.FirstOrDefault() != null;
    }
    protected string GenerateCollectionName(string entityName)
    {
        if (entityName.EndsWith("i"))
            entityName = entityName.Substring(0, entityName.Length - 1) + "es";
        else if (entityName.EndsWith("y"))
            entityName = entityName.Substring(0, entityName.Length - 1) + "ies";
        else
            entityName += "s";
        return entityName;
    }
}