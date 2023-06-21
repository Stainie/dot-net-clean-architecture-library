using DomainClean.Domain.Entities;
using DomainClean.Domain.Errors;
using DomainClean.Domain.Repositories;
using DomainClean.Utils;

namespace DomainClean.Domain.UseCases
{
    public class LoginUseCase
    {
        private readonly IUserRetrievalRepository userRetrievalRepository;

        public LoginUseCase(IUserRetrievalRepository userRetrievalRepository)
        {
            this.userRetrievalRepository = userRetrievalRepository;
        }

        public async Task<Result<UnableToFindUserEmail, User>> Call(string email, string password)
        {
            try
            {
                var user = await userRetrievalRepository.FindUserByEmailAddress(email);
                if (user.IsErr)
                {
                    return new Err<UnableToFindUserEmail, User>(new UnableToFindUserEmail("User not found."));
                }
                else
                {
                    return new Ok<UnableToFindUserEmail, User>(user.Value);

                    // TODO: Uncomment this when we have a password field on the user entity.

                    //if (user.Value.Password == password)
                    //{
                    //    return new Ok<UnableToFindUserEmail, User>(user.Value);
                    //}
                    //else
                    //{
                    //    return new Err<UnableToFindUserEmail, User>(new UnableToFindUserEmail("Password incorrect."));
                    //}
                }
            }
            catch (Exception e)
            {
                return new Err<UnableToFindUserEmail, User>(new UnableToFindUserEmail(e.Message));
            }
        }
    }
}
