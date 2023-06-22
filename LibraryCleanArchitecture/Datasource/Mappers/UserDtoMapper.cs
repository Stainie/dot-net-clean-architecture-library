using DomainClean.Datasource.DTOs;
using DomainClean.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainClean.Datasource.Mappers
{
    public static class UserDtoMapper
    {
        public static UserDto MapToDto(this User user)
        {
            return new UserDto() { Id = user.Id.MapToDto(), Password = user.Password, EmailAddress = user.EmailAddress, VerifiedAt = user.VerifiedAt, CreatedAt = user.CreatedAt };
        }

        public static UserIdDto MapToDto(this UserId userId)
        {
            return new UserIdDto(userId.ToString());
        }

        public static User MapToEntity(this UserDto userDto)
        {
            return new User(new UserId(userDto.Id.ToString()), userDto.Password, userDto.EmailAddress, userDto.VerifiedAt, userDto.CreatedAt);
        }
    }
}
