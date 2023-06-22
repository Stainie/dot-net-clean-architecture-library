using DomainClean.Datasource.DTOs;
using DomainClean.Datasource.Events;
using DomainClean.Datasource.Mappers;
using DomainClean.Domain.Entities;
using DomainClean.Domain.Errors;
using DomainClean.Infrastructure.Services;
using DomainClean.Utils;

namespace DomainClean.Datasource.Services
{

    public class UserService : IUserService
    {
        private readonly UserSqlContext userSqlContext;
        private readonly UserEventStore eventStore;

        public UserService(UserSqlContext userSqlContext, UserEventStore eventStore)
        {
            this.userSqlContext = userSqlContext;
            this.eventStore = eventStore;
        }

        public async Task<Result<UnableToRegisterUser, User>> CreateUser(string email, string password)
        {
            try
            {
                var userId = new UserIdDto();
                var userDto = new UserDto() { Id = userId, Password = password, EmailAddress = email, VerifiedAt = null, CreatedAt = new DateTime() };

                await userSqlContext.AddDomainAsync(userDto);

                var userCreatedEvent = new UserCreatedEvent(userId, email);
                await eventStore.AppentEventAsync(userId.Id, userCreatedEvent);

                return new Ok<UnableToRegisterUser, User>(userDto.MapToEntity());

            }
            catch (Exception e)
            {
                return new Err<UnableToRegisterUser, User>(new UnableToRegisterUser(e.Message));

            }
        }

        public async Task<Result<UnableToDeleteUser, User>> DeleteUser(UserId userId)
        {
            try
            {
                var userDto = await userSqlContext.GetDomainByIdAsync(userId.MapToDto());

                await userSqlContext.DeleteDomainAsync(userDto);

                var userDeletedEvent = new UserDeletedEvent(userId);
                await eventStore.AppentEventAsync(userId.id, userDeletedEvent);

                return new Ok<UnableToDeleteUser, User>(userDto.MapToEntity());
            }
            catch (Exception e)
            {
                return new Err<UnableToDeleteUser, User>(new UnableToDeleteUser(e.Message));
            }
        }

        public async Task<Result<UnableToFindUserEmail, User>> RetrieveUserByEmailAddress(string emailAddress)
        {
            try
            {
                var userDto = await userSqlContext.GetDomainByEmailAddressAsync(emailAddress);

                var userFoundByEmailEvent = new UserFoundByEmailEvent(userDto.Id, userDto.EmailAddress);
                await eventStore.AppentEventAsync(userDto.Id.Id, userFoundByEmailEvent);

                return new Ok<UnableToFindUserEmail, User>(userDto.MapToEntity());
            }
            catch (Exception e)
            {
                return new Err<UnableToFindUserEmail, User>(new UnableToFindUserEmail(e.Message));
            }
        }

        public async Task<Result<UnableToFindUserId, User>> RetrieveUserById(UserId id)
        {
            try
            {
                var userDto = await userSqlContext.GetDomainByIdAsync(id.MapToDto());

                var userFoundByIdEvent = new UserFoundByIdEvent(userDto.Id);
                await eventStore.AppentEventAsync(userDto.Id.Id, userFoundByIdEvent);

                return new Ok<UnableToFindUserId, User>(userDto.MapToEntity());
            }
            catch (Exception e)
            {
                return new Err<UnableToFindUserId, User>(new UnableToFindUserId(e.Message));
            }
        }

        public async Task<Result<UnableToUpdateUserEmail, User>> UpdateUserEmail(string email, UserId userId)
        {
            try
            {
                var userDto = await userSqlContext.GetDomainByIdAsync(userId.MapToDto());

                UserDto newUserDto = userDto with { EmailAddress = email, VerifiedAt = DateTime.UtcNow };

                await userSqlContext.UpdateDomainAsync(userDto);

                var userUpdatedEvent = new UserUpdatedEvent(userId, email, userDto.VerifiedAt);
                await eventStore.AppentEventAsync(userId.id, userUpdatedEvent);

                return new Ok<UnableToUpdateUserEmail, User>(userDto.MapToEntity());

            }
            catch (Exception e)
            {
                return new Err<UnableToUpdateUserEmail, User>(new UnableToUpdateUserEmail(e.Message));
            }
        }
    }
}
