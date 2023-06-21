namespace DomainClean.Domain.Errors
{
    public abstract class UserRetrievalErrors : Exception
    {
        public UserRetrievalErrors(string message) : base(message)
        {
        }
    }

    public class UnableToFindUserId : UserRetrievalErrors
    {
        public UnableToFindUserId(string message) : base("Unable to find user by Id")
        {
        }
    }

    public class UnableToFindUserEmail : UserRetrievalErrors
    {
        public UnableToFindUserEmail(string message) : base("Unable to find user by email address")
        {
        }
    }
}
