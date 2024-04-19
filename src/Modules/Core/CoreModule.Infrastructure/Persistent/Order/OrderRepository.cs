using Common.Infrastructure.Repository;
using CoreModule.Domain.Order.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CoreModule.Infrastructure.Persistent.Order;

class OrderRepository : BaseRepository<Domain.Order.Models.Order, CoreModuleEfContext>, IOrderRepository
{
    public OrderRepository(CoreModuleEfContext context) : base(context)
    {
    }

    public async Task<Domain.Order.Models.Order?> GetCurrentOrderByUserId(Guid userId)
    {
        return await Context.Orders.AsTracking()
            .FirstOrDefaultAsync(f => f.IsPay == false && f.UserId == userId);
    }
}