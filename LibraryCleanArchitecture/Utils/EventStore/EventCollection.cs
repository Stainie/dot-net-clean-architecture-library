namespace DomainClean.Utils.EventStore
{
    public class EventCollection<TEvent>
    {
        public IReadOnlyCollection<TEvent> Events { get; }
        public int Version { get; }

        public EventCollection(IReadOnlyCollection<TEvent> events, int version)
        {
            Events = events ?? throw new ArgumentNullException(nameof(events));
            if (version < 0)
            {
                throw new ArgumentException("Version must be a non-negative value.", nameof(version));
            }
            Version = version;
        }

        public EventCollection<TEvent> Append(TEvent @event)
        {
            var newEvents = new List<TEvent>(Events)
            {
                @event
            };
            return new EventCollection<TEvent>(newEvents, Version + 1);
        }

        public EventCollection<TEvent> AppendRange(IEnumerable<TEvent> events)
        {
            var newEvents = new List<TEvent>(Events);
            newEvents.AddRange(events);
            return new EventCollection<TEvent>(newEvents, Version + events.Count());
        }
    }
}
