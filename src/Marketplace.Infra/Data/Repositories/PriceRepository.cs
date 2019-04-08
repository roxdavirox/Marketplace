using Marketplace.Domain.Entities;
using Marketplace.Domain.Interfaces.Repositories;
using Marketplace.Infra.Data.EF.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

    public async Task<IEnumerable<Price>> GetByIdsAsync(IEnumerable<Guid> pricesIds)
    {
      var prices = _context.Prices.Where(p => pricesIds.Contains(p.Id));

      return await prices.ToListAsync();
    }

    public async Task<IEnumerable<Price>> GetPricesByPriceRangeIdAsync(Guid idPriceRange)
        {
            var priceRange = await _context.PriceRange
                .Include(_ => _.Prices)
                .FirstOrDefaultAsync(pr => pr.Id == idPriceRange);

            return priceRange.Prices.ToList();
        }

    public async Task<int> RemoveRangeAsync(IEnumerable<Price> prices)
    {
      _context.Prices.RemoveRange(prices);

      var deletedCount = prices.Count();

      return await Task.FromResult<int>(deletedCount);
    }
  }
}
