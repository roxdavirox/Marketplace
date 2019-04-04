using Marketplace.Domain.Entities;
using Marketplace.Domain.Interfaces.Repositories;
using Marketplace.Infra.Data.EF.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Marketplace.Infra.Data.Repositories
{
    public class PriceRangeRepository : IPriceRangeRepository
    {
        private readonly MarketplaceContext _context;

        public PriceRangeRepository(MarketplaceContext context)
        {
            _context = context;
        }

        public async Task<PriceRange> CreateAsync(PriceRange priceRange)
        {
            await _context.PriceRange.AddAsync(priceRange);
            return priceRange;
        }

        public async Task<IEnumerable<PriceRange>> GetAllAsync() =>
            await _context.PriceRange.ToListAsync();

        public async Task<PriceRange> GetByIdAsync(Guid idPriceRange) =>
            await _context.PriceRange.FindAsync(idPriceRange);
    }
}
