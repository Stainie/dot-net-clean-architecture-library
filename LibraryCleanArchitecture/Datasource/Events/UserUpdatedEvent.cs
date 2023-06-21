using DomainClean.Domain.Entities;
using DomainClean.Utils.EventStore;

namespace DomainClean.Datasource.Events
{
    internal class UserUpdatedEvent : IDomainEvent
    {
        private UserId userId;
        private string email;
        private DateTime? verifiedAt;
        public DateTime CreatedAt { get; }

        public UserUpdatedEvent(UserId userId, string email, DateTime? verifiedAt)
        {
            this.userId = userId;
            this.email = email;
            this.verifiedAt = verifiedAt;
            CreatedAt = DateTime.UtcNow;
        }

    }
}