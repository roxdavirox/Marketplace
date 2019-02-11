using Marketplace.Domain.Entities;
using Marketplace.Domain.Interfaces.Repositories;
using Marketplace.Infra.Data.EF.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Marketplace.Infra.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MarketplaceContext _context;

        public UserRepository(MarketplaceContext context)
        {
            _context = context;
        }

        public async Task<User> CreateAsync(User user)
        {
            await _context.Users.AddAsync(user);

            return user;
        }

        public async Task<User> AuthenticateAsync(string email, string password)
        {
            var authenticatedUser = await _context.Users.FirstOrDefaultAsync(
                    u => u.Email == email && u.Password == password
                );

            return authenticatedUser;
        }

    }
}
