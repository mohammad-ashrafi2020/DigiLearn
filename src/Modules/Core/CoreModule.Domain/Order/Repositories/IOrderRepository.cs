using Common.Domain.Repository;

namespace CoreModule.Domain.Order.Repositories;

public interface IOrderRepository : IBaseRepository<Models.Order>
{
    Task<Models.Order?> GetCurrentOrderByUserId(Guid userId);
}