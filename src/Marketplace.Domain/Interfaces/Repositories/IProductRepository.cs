using Marketplace.Domain.Entities;
using System.Threading.Tasks;

namespace Marketplace.Domain.Interfaces.Repositories
{
    public interface IProductRepository
    {
        void Create(Product product);
        Task<Product> CreateAsync(Product product);
    }
}
