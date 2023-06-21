using DomainClean.Domain.Entities;
using DomainClean.Utils.EventStore;

namespace DomainClean.Datasource.Events
{
    internal class UserDeletedEvent : IDomainEvent
    {
        private UserId userId;
        public DateTime CreatedAt { get; }

        public UserDeletedEvent(UserId userId)
        {
            this.userId = userId;
            CreatedAt = DateTime.UtcNow;
        }

    }
}