using Common.EventBus.Abstractions;

namespace Common.EventBus.Events;

public class NewNotificationIntegrationEvent : IntegrationEvent
{
    public Guid UserId { get; set; }
    public string Title { get; set; }
    public string Message { get; set; }
    public DateTime CreationDate { get; set; }
}