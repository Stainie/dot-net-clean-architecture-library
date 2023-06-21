using DomainClean.Domain.Entities;
using DomainClean.Domain.Errors;
using DomainClean.Utils;

namespace DomainClean.Domain.Repositories
{
    public interface IUserManipulationRepository
    {
        Task<Result<UnableToRegisterUser, User>> Register(string email, string password);

        Task<Result<UnableToUpdateUserEmail, User>> UpdateEmail(string email, UserId userId);

        Task<Result<UnableToDeleteUser, User>> DeleteAccount(UserId userId);
    }
}
