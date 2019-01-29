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

        public async Task CreateAsync(IEnumerable<Price> prices)
        {
            await _context.Prices.AddRangeAsync(prices);
        }
    }
}
