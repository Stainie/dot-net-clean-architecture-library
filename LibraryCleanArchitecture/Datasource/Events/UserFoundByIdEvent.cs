using DomainClean.Datasource.DTOs;
using DomainClean.Utils.EventStore;

namespace DomainClean.Datasource.Events
{
    internal class UserFoundByIdEvent : IDomainEvent
    {
        private UserIdDto id;
        public DateTime CreatedAt { get; }

        public UserFoundByIdEvent(UserIdDto id)
        {
            this.id = id;
            CreatedAt = DateTime.UtcNow;
        }

    }
}