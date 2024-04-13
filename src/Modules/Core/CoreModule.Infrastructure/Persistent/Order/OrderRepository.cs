using Common.Infrastructure.Repository;
using CoreModule.Domain.Order.Repositories;

namespace CoreModule.Infrastructure.Persistent.Order;

class OrderRepository : BaseRepository<Domain.Order.Models.Order, CoreModuleEfContext>, IOrderRepository
{
    public OrderRepository(CoreModuleEfContext context) : base(context)
    {
    }
}