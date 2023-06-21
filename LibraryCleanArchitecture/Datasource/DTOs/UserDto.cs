using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainClean.Datasource.DTOs
{
    // For this purpose, Dto will same structure as the entity.
    // However, in a lot of scenarios, the data retrieved from the external source will be different to the data needed for the business case.
    // Of course, Password should be hashed and salted, and not saved like this. ust for the sake of the example
    public record UserDto
    {
        public UserIdDto Id { get; init; } = new UserIdDto();
        public string Password { get; init; } = string.Empty;
        public string EmailAddress { get; init; } = string.Empty;
        public DateTime? VerifiedAt { get; init; }
        public DateTime CreatedAt { get; init; }

    }
}
