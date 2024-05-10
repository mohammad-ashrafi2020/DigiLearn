using Common.Query;
using CoreModule.Query._Data;
using CoreModule.Query.Order._DTOs;
using Microsoft.EntityFrameworkCore;

namespace CoreModule.Query.Order.GetCurrent;

public record GetCurrentOrderQuery(Guid UserId) : IQuery<OrderDto?>;



class GetCurrentOrderQueryHandler : IQueryHandler<GetCurrentOrderQuery, OrderDto?>
{
    private readonly QueryContext _context;

    public GetCurrentOrderQueryHandler(QueryContext context)
    {
        _context = context;
    }

    public async Task<OrderDto?> Handle(GetCurrentOrderQuery request, CancellationToken cancellationToken)
    {
        var order = await _context.Orders
            .Include(c => c.OrderItems)
            .ThenInclude(c => c.Course.Teacher.User)
            .Include(c => c.User)
            .FirstOrDefaultAsync(f => f.UserId == request.UserId && f.IsPay == false
                , cancellationToken: cancellationToken);

        return OrderMapper.MapOrder(order);
    }
}