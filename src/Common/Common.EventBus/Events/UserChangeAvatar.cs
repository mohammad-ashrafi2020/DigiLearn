using Common.EventBus.Abstractions;

namespace Common.EventBus.Events;

public class UserChangeAvatar : IntegrationEvent
{
    public Guid UserId { get; set; }
    public string Avatar { get; set; }
}