using DomainClean.Utils.EventStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainClean.Datasource.Services
{
    // The same as the Sql implementation, this is also a fake local implementation of the event store.
    // In the real world, this would be a message queue, or something else.
    public class UserEventStore : IEventStore
    {
        private readonly Dictionary<Guid, EventCollection<IDomainEvent>> eventStore;

        public UserEventStore()
        {
            eventStore = new Dictionary<Guid, EventCollection<IDomainEvent>>();
        }
        public Task AppendEventStreamAsync(Guid aggregateId, EventCollection<IDomainEvent> eventStream)
        {
            if (eventStore.ContainsKey(aggregateId))
            {
                var existingEvents = eventStore[aggregateId];
                existingEvents.AppendRange(eventStream.Events);
            }
            else
            {
                eventStore[aggregateId] = eventStream;
            }

            return Task.CompletedTask;
        }

        public Task AppentEventAsync(Guid aggregateId, IDomainEvent @event)
        {
            if (eventStore.ContainsKey(aggregateId))
            {
                var existingEvents = eventStore[aggregateId];
                existingEvents.Append(@event);
            }
            else
            {
                eventStore[aggregateId] = new EventCollection<IDomainEvent>(new List<IDomainEvent> { @event }, 0);
            }

            return Task.CompletedTask;
        }

        public Task<EventCollection<IDomainEvent>> GetEventsAsync(Guid aggregateId)
        {
            if (eventStore.ContainsKey(aggregateId))
            {
                var events = eventStore[aggregateId];
                return Task.FromResult(events);
            }

            return Task.FromResult<EventCollection<IDomainEvent>>(null);
        }
    }

}
