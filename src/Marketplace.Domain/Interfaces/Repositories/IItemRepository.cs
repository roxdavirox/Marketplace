using Marketplace.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Marketplace.Domain.Interfaces.Repositories
{
    public interface IItemRepository
    {
        Task<Item> CreateAsync(Item item);
        Task CreateRangeAsync(IEnumerable<Item> items);
        Task<Item> GetByIdAsync(Guid IdItem);
        Task<IEnumerable<Item>> GetByIdsAsync(IEnumerable<Guid> itemsIds);
        Task<IEnumerable<Item>> GetByOptionIdAsync(Guid idOption);
        Task<int> RemoveRange(IEnumerable<Item> items);
    }
}
