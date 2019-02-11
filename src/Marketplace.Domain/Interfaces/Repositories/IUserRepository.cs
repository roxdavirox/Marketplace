using Marketplace.Domain.Entities;
using System.Threading.Tasks;

namespace Marketplace.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User> CreateAsync(User user);
        Task<User> AuthenticateAsync(string email, string password);
    }
}
