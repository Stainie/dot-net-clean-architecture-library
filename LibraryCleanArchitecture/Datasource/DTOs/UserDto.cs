using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainClean.Datasource.DTOs
{
    // For this purpose, Dto will same structure as the entity.
    // However, in a lot of scenarios, the data retrieved from the external source will be different to the data needed for the business case.
    public class UserDto
    {
        public UserIdDto Id { get; private set; }

        // Of course, Password should be hashed and salted, and not saved like this. ust for the sake of the example
        public string Password { get; private set; }

        public string EmailAddress { get; set; }

        public DateTime? VerifiedAt { get; set; }

        public DateTime CreatedAt { get; private set; }

        public UserDto(UserIdDto id, string password, string emailAddress, DateTime? verifiedAt, DateTime createdAt)
        {
            Id = id;
            Password = password;
            EmailAddress = emailAddress;
            VerifiedAt = verifiedAt;
            CreatedAt = createdAt;
        }
    }
}
