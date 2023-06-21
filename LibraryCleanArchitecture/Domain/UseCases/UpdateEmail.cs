using DomainClean.Domain.Entities;
using DomainClean.Domain.Errors;
using DomainClean.Domain.Repositories;
using DomainClean.Utils;

namespace DomainClean.Domain.UseCases
{
    public class UpdateEmail
    {
        private readonly IUserManipulationRepository userManipulationRepository;

        public UpdateEmail(IUserManipulationRepository userManipulationRepository)
        {
            this.userManipulationRepository = userManipulationRepository;
        }

        public async Task<Result<UnableToUpdateUserEmail, User>> Call(string email, UserId userId)
        {
            try
            {
                return await userManipulationRepository.UpdateEmail(email, userId);
            }
            catch (Exception e)
            {
                return new Err<UnableToUpdateUserEmail, User>(new UnableToUpdateUserEmail(e.Message));
            }
        }
    }
}
