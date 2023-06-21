using DomainClean.Domain.Entities;
using DomainClean.Domain.Errors;
using DomainClean.Domain.Repositories;
using DomainClean.Utils;

namespace DomainClean.Domain.UseCases
{
    public class RegisterUseCase
    {
        private readonly IUserManipulationRepository userManipulationRepository;
        
        public RegisterUseCase(IUserManipulationRepository userManipulationRepository)
        {
            this.userManipulationRepository = userManipulationRepository;
        }

        public async Task<Result<UnableToRegisterUser, User>> Call(string email, string password)
        {
            try
            {
                return await userManipulationRepository.Register(email, password);
            }
            catch (Exception e)
            {
                return new Err<UnableToRegisterUser, User>(new UnableToRegisterUser(e.Message));
            }
        }
    }
}
