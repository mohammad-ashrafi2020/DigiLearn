using Common.Application;
using CoreModule.Domain.Order.DomainServices;
using CoreModule.Domain.Order.Repositories;

namespace CoreModule.Application.Order.AddItem;

public class AddOrderItemCommandHandler : IBaseCommandHandler<AddOrderItemCommand>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IOrderDomainService _domainService;

    public AddOrderItemCommandHandler(IOrderRepository orderRepository, IOrderDomainService domainService)
    {
        _orderRepository = orderRepository;
        _domainService = domainService;
    }

    public async Task<OperationResult> Handle(AddOrderItemCommand request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetCurrentOrderByUserId(request.UserId);
        if (order == null)
        {
            var newOrder = new Domain.Order.Models.Order(request.UserId);
            await newOrder.AddItem(request.CourseId, _domainService);
            _orderRepository.Add(newOrder);
        }
        else
        {
            await order.AddItem(request.CourseId, _domainService);
        }

        await _orderRepository.Save();
        return OperationResult.Success();
    }
}