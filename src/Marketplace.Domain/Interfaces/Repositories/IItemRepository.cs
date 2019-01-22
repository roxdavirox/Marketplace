using Marketplace.Domain.Entities;
using System.Threading.Tasks;

namespace Marketplace.Domain.Interfaces.Repositories
{
    public interface IItemRepository
    {
        Task<Item> CreateAsync(Item item);
    }
}
