using Common.Application;
using CoreModule.Application.Order.AddItem;
using CoreModule.Application.Order.RemoveItem;
using CoreModule.Query.Order._DTOs;
using CoreModule.Query.Order.GetCurrent;
using MediatR;

namespace CoreModule.Facade.Orders;

public interface IOrderFacade
{
    Task<OperationResult> AddItem(AddOrderItemCommand command);
    Task<OperationResult> RemoveItem(RemoveOrderItemCommand command);


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

    public async Task<OrderDto?> GetCurrentOrder(Guid userId)
    {
        return await _mediator.Send(new GetCurrentOrderQuery(userId));

    }
}