using DomainClean.Domain.Entities;
using DomainClean.Domain.Errors;
using DomainClean.Utils;

namespace DomainClean.Infrastructure.Services
{
    public interface IUserService
    {
        Task<Result<UnableToFindUserEmail, User>> RetrieveUserByEmailAddress(string emailAddress);

        Task<Result<UnableToFindUserId, User>> RetrieveUserById(UserId id);

        Task<Result<UnableToRegisterUser, User>> CreateUser(string email, string password);

        Task<Result<UnableToUpdateUserEmail, User>> UpdateUserEmail(string email, UserId userId);

        Task<Result<UnableToDeleteUser, User>> DeleteUser(UserId userId);
    }
}
