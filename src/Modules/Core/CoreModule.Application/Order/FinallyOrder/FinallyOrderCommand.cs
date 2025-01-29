using Common.Application;
using CoreModule.Domain.Order.Repositories;
using MediatR;

namespace CoreModule.Application.Order.FinallyOrder;

public class FinallyOrderCommand : IBaseCommand
{
    public Guid OrderId { get; set; }
}
class FinallyOrderCommandHandler : IBaseCommandHandler<FinallyOrderCommand>
{
    private readonly IOrderRepository _repository;

    public FinallyOrderCommandHandler(IOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(FinallyOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _repository.GetTracking(request.OrderId);
        if (order == null)
        {
            return OperationResult.NotFound();
        }
        order.FinallyOrder();
        await _repository.Save();
        return OperationResult.Success();
    }
}