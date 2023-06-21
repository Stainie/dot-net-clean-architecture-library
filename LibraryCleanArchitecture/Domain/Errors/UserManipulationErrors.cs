namespace DomainClean.Domain.Errors
{
    public abstract class UserManipulationErrors : Exception
    {
        public UserManipulationErrors(string message) : base(message)
        {
        }
    }

    public class UnableToRegisterUser : UserManipulationErrors
    {
        public UnableToRegisterUser(string message) : base("Unable to register user")
        {
        }
    }

    public class UnableToUpdateUserEmail : UserManipulationErrors
    {
        public UnableToUpdateUserEmail(string message) : base("Unable to update user email")
        {
        }
    }

    public class UnableToDeleteUser : UserManipulationErrors
    {
        public UnableToDeleteUser(string message) : base("Unable to delete user")
        {
        }
    }
}
