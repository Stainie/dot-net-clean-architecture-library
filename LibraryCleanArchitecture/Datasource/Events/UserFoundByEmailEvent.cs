using DomainClean.Datasource.DTOs;
using DomainClean.Utils.EventStore;

namespace DomainClean.Datasource.Events
{
    internal class UserFoundByEmailEvent : IDomainEvent
    {
        private UserIdDto id;
        private string emailAddress;
        public DateTime CreatedAt { get; }

        public UserFoundByEmailEvent(UserIdDto id, string emailAddress)
        {
            this.id = id;
            this.emailAddress = emailAddress;
            CreatedAt = DateTime.UtcNow;
        }

    }
}