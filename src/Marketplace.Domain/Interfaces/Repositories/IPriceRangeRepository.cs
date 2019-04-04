using Marketplace.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Marketplace.Domain.Interfaces.Repositories
{
    public interface IPriceRangeRepository
    {
        Task<PriceRange> CreateAsync(PriceRange priceRange);
        Task<PriceRange> GetByIdAsync(Guid idPriceRange);
    }
}
