using Marketplace.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Marketplace.Domain.Interfaces.Repositories
{
    public interface IPriceRepository
    {
        Task CreateRangeAsync(IEnumerable<Price> prices);
    }
}
