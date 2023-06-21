using DomainClean.Domain.Entities;
using DomainClean.Domain.Errors;
using DomainClean.Domain.Repositories;
using DomainClean.Utils;

namespace DomainClean.Domain.UseCases
{
    public class DeleteUserUseCase
    {
        private readonly IUserManipulationRepository userManipulationRepository;

        public DeleteUserUseCase(IUserManipulationRepository userManipulationRepository)
        {
            this.userManipulationRepository = userManipulationRepository;
        }

        public async Task<Result<UnableToDeleteUser, User>> Call(UserId userId)
        {
            try
            {
                return await userManipulationRepository.DeleteAccount(userId);
            }
            catch (Exception e)
            {
                return new Err<UnableToDeleteUser, User>(new UnableToDeleteUser(e.Message));
            }
        }
    }
}
