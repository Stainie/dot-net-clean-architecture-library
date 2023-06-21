using DomainClean.Domain.Entities;
using DomainClean.Domain.Errors;
using DomainClean.Domain.Repositories;
using DomainClean.Infrastructure.Services;
using DomainClean.Utils;

namespace DomainClean.Infrastructure.Repositories
{
    public class UserManipulationRepository : IUserManipulationRepository
    {
        private readonly IUserService userService;

        public UserManipulationRepository(IUserService userService)
        {
            this.userService = userService;
        }
        public async Task<Result<UnableToDeleteUser, User>> DeleteAccount(UserId userId)
        {
            try
            {
                var result = await userService.DeleteUser(userId);

                if (result.IsErr)
                {
                    return new Err<UnableToDeleteUser, User>(new UnableToDeleteUser(result.Error.Message));
                }
                else
                {
                    return new Ok<UnableToDeleteUser, User>(result.Value);
                }
            }
            catch (Exception ex)
            {
                return new Err<UnableToDeleteUser, User>(new UnableToDeleteUser(ex.Message));
            }
        }

        public async Task<Result<UnableToRegisterUser, User>> Register(string email, string password)
        {
            try
            {
                var result = await userService.CreateUser(email, password);

                if (result.IsErr)
                {
                    return new Err<UnableToRegisterUser, User>(new UnableToRegisterUser(result.Error.Message));
                }
                else
                {
                    if (result.Value == null)
                    {
                          return new Err<UnableToRegisterUser, User>(new UnableToRegisterUser("User not found."));
                    }
                    return new Ok<UnableToRegisterUser, User>(result.Value);
                }
            }
            catch (Exception ex)
            {
                return new Err<UnableToRegisterUser, User>(new UnableToRegisterUser(ex.Message));
            }
        }

        public async Task<Result<UnableToUpdateUserEmail, User>> UpdateEmail(string email, UserId userId)
        {
            try
            {
                var result = await userService.UpdateUserEmail(email, userId);

                if (result.IsErr)
                {
                    return new Err<UnableToUpdateUserEmail, User>(new UnableToUpdateUserEmail(result.Error.Message));
                }
                else
                {
                    if (result.Value == null)
                    {
                        return new Err<UnableToUpdateUserEmail, User>(new UnableToUpdateUserEmail("User not found."));
                    }
                    return new Ok<UnableToUpdateUserEmail, User>(result.Value);
                }
            }
            catch (Exception ex)
            {
                return new Err<UnableToUpdateUserEmail, User>(new UnableToUpdateUserEmail(ex.Message));
            }
        }
    }
}
