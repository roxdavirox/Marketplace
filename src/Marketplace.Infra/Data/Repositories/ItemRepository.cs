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

        public async Task<IEnumerable<Item>> GetItemsByOptionIdAsync(Guid idOption)
        {
            var option = await _context.Options
                .Include(o => o.Items)
                .Include(o => o.Items)
                    .ThenInclude(i => i.PriceRange)
                .FirstOrDefaultAsync(o => o.Id == idOption);

            var items = option.Items.ToList();

            return items;
        }

        public async Task CreateRangeAsync(IEnumerable<Item> items) =>
            await _context.Items.AddRangeAsync(items);

        public async Task<Item> GetByIdAsync(Guid idItem) =>
            await Task.FromResult(_context.Items
                        .Include(i => i.PriceRange)
                        .FirstOrDefault(i => i.Id == idItem)
                );

        public async Task<int> RemoveRange(IEnumerable<Item> items)
        {
            _context.Items.RemoveRange(items);

            var deletedItems = items.Count();

            return await Task.FromResult<int>(deletedItems);
        }
    }
}
