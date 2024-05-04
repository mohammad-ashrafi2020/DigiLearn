using Common.Query;
using CoreModule.Query._Data;
using CoreModule.Query.Order._DTOs;
using Microsoft.EntityFrameworkCore;

namespace CoreModule.Query.Order.GetByFilter;

public class GetOrderByFilterQuery : QueryFilter<OrderFilterResult, OrderFilterParams>
{
    public GetOrderByFilterQuery(OrderFilterParams filterParams) : base(filterParams)
    {
    }
}
class GetOrderByFilterQueryHandler : IQueryHandler<GetOrderByFilterQuery, OrderFilterResult>
{
    private readonly QueryContext _context;

    public GetOrderByFilterQueryHandler(QueryContext context)
    {
        _context = context;
    }

    public async Task<OrderFilterResult> Handle(GetOrderByFilterQuery request, CancellationToken cancellationToken)
    {
        var result = _context.Orders.Include(c => c.User)
            .Include(c => c.OrderItems).AsSplitQuery();


        if (request.FilterParams.UserId != null)
        {
            result = result.Where(r => r.UserId == request.FilterParams.UserId);
        }

        switch (request.FilterParams.Status)
        {
            case OrderFilterStatus.All:
                break;
            case OrderFilterStatus.Completed:
                result = result.Where(r => r.IsPay == true);
                break;
            case OrderFilterStatus.Pending:
                result = result.Where(r => r.IsPay == false);
                break;
            default:
                break;
        }

        if (request.FilterParams.StartDate != null)
        {
            result = result.Where(r => r.PaymentDate.Value.Date <= request.FilterParams.StartDate.Value.Date);
        }
        if (request.FilterParams.EndDate != null)
        {
            result = result.Where(r => r.PaymentDate.Value.Date >= request.FilterParams.EndDate.Value.Date);
        }

        var skip = (request.FilterParams.PageId - 1) * request.FilterParams.Take;
        var model = new OrderFilterResult()
        {
            Data = await result.Skip(skip).Take(request.FilterParams.Take)
                .Select(s => new OrderFilterData
                {
                    Id = s.Id,
                    CreationDate = s.CreationDate,
                    ItemCount = s.OrderItems.Count,
                    TotalPrice = s.OrderItems.Sum(s => s.Price),
                    PaymentDate = s.PaymentDate,
                    IsPay = s.IsPay,
                    UserFullName = s.User.FullName ?? s.User.PhoneNumber,
                    UserId = default
                }).ToListAsync(cancellationToken)
        };
        model.GeneratePaging(result, request.FilterParams.Take, request.FilterParams.PageId);
        return model;
    }
}