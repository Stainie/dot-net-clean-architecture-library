using DomainClean.Datasource.DTOs;
using DomainClean.Utils.EventStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainClean.Datasource.Events
{
    public class UserCreatedEvent : IDomainEvent
    {
        public DateTime CreatedAt { get; }

        public UserIdDto UserId { get; }
        public string Email { get; }

        public UserCreatedEvent(UserIdDto userId, string email)
        {
            UserId = userId;
            Email = email;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
