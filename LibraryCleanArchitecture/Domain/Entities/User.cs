namespace DomainClean.Domain.Entities
{
    public class User
    {
        public UserId Id { get; private set; }

        // Of course, Password should be hashed and salted, and not saved like this. ust for the sake of the example
        public string Password { get; private set; }

        public string EmailAddress { get; private set; }

        public DateTime? VerifiedAt { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public User(UserId id, string password, string emailAddress, DateTime? verifiedAt, DateTime createdAt)
        {
            Id = id;
            Password = password;
            EmailAddress = emailAddress;
            VerifiedAt = verifiedAt;
            CreatedAt = createdAt;
        }
    }
}
