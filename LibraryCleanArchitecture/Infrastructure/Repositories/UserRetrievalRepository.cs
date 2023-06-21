using DomainClean.Domain.Entities;
using DomainClean.Domain.Errors;
using DomainClean.Domain.Repositories;
using DomainClean.Infrastructure.Services;
using DomainClean.Utils;

namespace DomainClean.Infrastructure.Repositories
{
    public class UserRetrievalRepository : IUserRetrievalRepository
    {
        private readonly IUserService userService;

        public UserRetrievalRepository(IUserService userService)
        {
            this.userService = userService;
        }
        public async Task<Result<UnableToFindUserEmail, User>> FindUserByEmailAddress(string emailAddress)
        {
            try
            {
                var result = await userService.RetrieveUserByEmailAddress(emailAddress);

                if (result.IsErr)
                {
                    return new Err<UnableToFindUserEmail, User>(new UnableToFindUserEmail(result.Error.Message));
                }
                else
                {
                    if (result.Value == null)
                    {
                        return new Err<UnableToFindUserEmail, User>(new UnableToFindUserEmail("User not found."));
                    }

                    if (result.Value.EmailAddress != emailAddress)
                    {
                        return new Err<UnableToFindUserEmail, User>(new UnableToFindUserEmail("Email invalid."));
                    }

                    return new Ok<UnableToFindUserEmail, User>(result.Value);
                }
            }
            catch (Exception ex)
            {
                return new Err<UnableToFindUserEmail, User>(new UnableToFindUserEmail(ex.Message));
            }
        }

        public async Task<Result<UnableToFindUserId, User>> FindUserById(UserId id)
        {
            try
            {
                var result = await userService.RetrieveUserById(id);

                if (result.IsErr)
                {
                    return new Err<UnableToFindUserId, User>(new UnableToFindUserId(result.Error.Message));
                }
                else
                {
                    if (result.Value == null)
                    {
                        return new Err<UnableToFindUserId, User>(new UnableToFindUserId("User not found."));
                    }

                    if (result.Value.Id != id)
                    {
                        return new Err<UnableToFindUserId, User>(new UnableToFindUserId("Id invalid."));
                    }

                    return new Ok<UnableToFindUserId, User>(result.Value);
                }
            }
            catch (Exception ex)
            {
                return new Err<UnableToFindUserId, User>(new UnableToFindUserId(ex.Message));
            }
        }
    }
}
