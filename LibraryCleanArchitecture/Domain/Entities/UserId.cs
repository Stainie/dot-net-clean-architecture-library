namespace DomainClean.Domain.Entities
{
    public class UserId
    {
        public readonly Guid id;

        public UserId()
        {
            id = Guid.NewGuid();
        }

        public UserId(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException("Id is null, empty or whitespace.", nameof(id));
            }

            if (!Guid.TryParse(id, out var parsedId))
            {
                throw new ArgumentException("Unable to parse id as Guid.", nameof(id));
            }

            this.id = parsedId;
        }

        public override string ToString() => id.ToString();
    }
}
