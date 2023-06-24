using Common.EventBus.Abstractions;

namespace Common.EventBus.Events;

public class UserRegistered : IntegrationEvent
{
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
}