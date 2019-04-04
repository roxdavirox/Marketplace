using Marketplace.Domain.Entities;
using Marketplace.Domain.Interfaces.Repositories;
using Marketplace.Infra.Data.EF.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Marketplace.Infra.Data.Repositories
{
    public class PriceRepository : IPriceRepository
    {
        private readonly MarketplaceContext _context;

        public PriceRepository(MarketplaceContext context)
        {
            _context = context;
        }

        public async Task<Price> CreateAsync(Price price)
        {
            await _context.Prices.AddAsync(price);
            return price;
        }

        public async Task CreateRangeAsync(IEnumerable<Price> prices)
        {
            await _context.Prices.AddRangeAsync(prices);
        }
    }
}
