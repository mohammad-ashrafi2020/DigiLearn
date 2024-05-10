using Common.Application;
using CoreModule.Domain.Order.Repositories;

namespace CoreModule.Application.Order.RemoveItem;

public class RemoveOrderItemCommandHandler:IBaseCommandHandler<RemoveOrderItemCommand>
{
    private readonly IOrderRepository _orderRepository;

    public RemoveOrderItemCommandHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<OperationResult> Handle(RemoveOrderItemCommand request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetCurrentOrderByUserId(request.UserId);
        if (order == null)
        {
            return OperationResult.NotFound();
        }

        order.RemoveItem(request.Id);
        await _orderRepository.Save();
        return OperationResult.Success();
    }
}