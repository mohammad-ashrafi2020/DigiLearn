using Common.Domain;

namespace CoreModule.Domain.Order.Events;

public class OrderFinallyEvent : BaseDomainEvent
{
    public Guid UserId { get; set; }
    public Guid OrderId { get; set; }
}