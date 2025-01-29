using Common.Application;
using CoreModule.Application.Order.AddItem;
using CoreModule.Application.Order.FinallyOrder;
using CoreModule.Application.Order.RemoveItem;
using CoreModule.Query.Order._DTOs;
using CoreModule.Query.Order.GetCurrent;
using MediatR;

namespace CoreModule.Facade.Orders;

public interface IOrderFacade
{
    Task<OperationResult> AddItem(AddOrderItemCommand command);
    Task<OperationResult> RemoveItem(RemoveOrderItemCommand command);
    Task<OperationResult> FinallyOrder(Guid orderId);

    Task<OrderDto?> GetCurrentOrder(Guid userId);
}
class OrderFacade : IOrderFacade
{
    private readonly IMediator _mediator;

    public OrderFacade(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<OperationResult> AddItem(AddOrderItemCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> RemoveItem(RemoveOrderItemCommand command)
    {
        return await _mediator.Send(command);

    }

    public async Task<OperationResult> FinallyOrder(Guid orderId)
    {
        return await _mediator.Send(new FinallyOrderCommand()
        {
            OrderId = orderId
        });
    }

    public async Task<OrderDto?> GetCurrentOrder(Guid userId)
    {
        return await _mediator.Send(new GetCurrentOrderQuery(userId));

    }
}