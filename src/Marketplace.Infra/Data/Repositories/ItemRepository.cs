using Marketplace.Domain.Entities;
using Marketplace.Domain.Interfaces.Repositories;
using Marketplace.Infra.Data.EF.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Marketplace.Infra.Data.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly MarketplaceContext _context;

        public ItemRepository(MarketplaceContext context)
        {
            _context = context;
        }

        public async Task<Item> CreateAsync(Item item)
        {
            await _context.Items.AddAsync(item);
            return item;
        }

        public async Task CreateRangeAsync(IEnumerable<Item> items) =>
            await _context.Items.AddRangeAsync(items);

        public async Task<Item> GetByIdAsync(Guid idItem) =>
            await _context.Items.FindAsync(idItem);
    }
}
