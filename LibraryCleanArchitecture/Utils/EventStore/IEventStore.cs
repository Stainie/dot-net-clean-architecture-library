
namespace DomainClean.Utils.EventStore
{
    public interface IEventStore
    {
        Task<EventCollection<IDomainEvent>> GetEventsAsync(Guid aggregateId);

        Task AppentEventAsync(Guid aggregateId, IDomainEvent @event);

        Task AppendEventStreamAsync(Guid aggregateId, EventCollection<IDomainEvent> eventStream);
    }

    public interface IDomainEvent
    {
        DateTime CreatedAt { get; }
    }
}
