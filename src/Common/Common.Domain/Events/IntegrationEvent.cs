using System.Text.Json.Serialization;

namespace Common.Domain.Events;
public class IntegrationEvent
{
    public IntegrationEvent()
    {
        EventId = Guid.NewGuid();
        CreationDate = DateTime.UtcNow;
    }

    [JsonConstructor]
    public IntegrationEvent(Guid id, DateTime createDate)
    {
        EventId = id;
        CreationDate = createDate;
    }

    [JsonInclude]
    public Guid EventId { get; private init; }

    [JsonInclude]
    public DateTime CreationDate { get; private init; }

    public string EventType { get; protected set; }
}
