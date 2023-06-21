using DomainClean.Domain.Entities;
using DomainClean.Domain.Errors;
using DomainClean.Utils;

namespace DomainClean.Domain.Repositories
{
    public interface IUserRetrievalRepository
    {
        Task<Result<UnableToFindUserId, User>> FindUserById(UserId id);

        Task<Result<UnableToFindUserEmail, User>> FindUserByEmailAddress(string emailAddress);
    }
}
