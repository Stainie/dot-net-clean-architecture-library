namespace DomainClean.Utils.Database
{
    public interface ISqlDatabaseContext<T, ID>
    {
        IReadOnlyCollection<T> Domains { get; }

        Task<IEnumerable<T>> GetDomainsAsync();

        Task<T> GetDomainByIdAsync(ID id);

        Task AddDomainAsync(T domain);

        Task UpdateDomainAsync(T domain);

        Task DeleteDomainAsync(T domain);


        // An extra step for this would be to create a SqlSuccess and SqlError class that would be returned inside SaveChangesAsync implementation
        // This would allow us to return a Result<SqlError, SqlSuccess> and handle the errors in the service layer
        // There is a Map method in the Result class that would allow us to map the SqlError to a domain error
        Task SaveChangesAsync();
    }
}
