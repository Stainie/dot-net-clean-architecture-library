using DomainClean.Datasource.DTOs;
using DomainClean.Utils.Database;

namespace DomainClean.Datasource.Services
{
    // In this example, all the changes are perfomed locally in memory, but in a real application, this would be a database context / cache

    public class UserSqlContext : ISqlDatabaseContext<UserDto, UserIdDto>
    {
        private readonly List<UserDto> users;

        public UserSqlContext(List<UserDto> users)
        {
            this.users = users;
        }
        public IReadOnlyCollection<UserDto> Domains => users.AsReadOnly();

        public Task<IEnumerable<UserDto>> GetDomainsAsync() => Task.FromResult(users.AsEnumerable());

        public Task<UserDto> GetDomainByIdAsync(UserIdDto id) => Task.FromResult(users.FirstOrDefault(user => user.Id == id));

        public Task AddDomainAsync(UserDto user)
        {
            users.Add(user);
            return SaveChangesAsync();
        }

        public Task UpdateDomainAsync(UserDto user)
        {
            // Locking the thread so only one thread can modify the critical section at once
            lock (users)
            {
                var existingUser = users.FirstOrDefault(u => u.Id == user.Id);
                if (existingUser != null)
                {
                    users.Remove(existingUser);
                    users.Add(user);
                    return SaveChangesAsync();
                }
                else
                {
                    throw new Exception("User not found");
                }
            }
        }

        public Task DeleteDomainAsync(UserDto user)
        {
            users.Remove(user);
            return SaveChangesAsync();
        }

        public Task SaveChangesAsync()
        {
            return Task.CompletedTask;
        }

        public Task<UserDto> GetDomainByEmailAddressAsync(string emailAddress) => Task.FromResult(users.FirstOrDefault(user => user.EmailAddress == emailAddress));
    }
}
