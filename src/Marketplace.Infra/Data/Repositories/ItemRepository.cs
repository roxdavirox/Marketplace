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

        public async Task<IEnumerable<Item>> GetByIdsAsync(IEnumerable<Guid> itemsIds)
        {
            var items = _context.Items.Where(i => itemsIds.Contains(i.Id));

            return await items.ToListAsync();
        }

        public async Task<IEnumerable<Item>> GetByOptionIdAsync(Guid idOption)
        {
            var option = await _context.Options
                .Include(o => o.Items)
                .FirstOrDefaultAsync(o => o.Id == idOption);

            return option.Items.ToList();
        }

        public async Task CreateRangeAsync(IEnumerable<Item> items) =>
            await _context.Items.AddRangeAsync(items);

        public async Task<Item> GetByIdAsync(Guid idItem) =>
            await _context.Items.FindAsync(idItem);

        public async Task<int> RemoveRange(IEnumerable<Item> items)
        {
            _context.Items.RemoveRange(items);

            var deletedItems = items.Count();

            return await Task.FromResult<int>(deletedItems);
        }
    }
}
