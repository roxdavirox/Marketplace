using Marketplace.Domain.Entities;

namespace Marketplace.Domain.Interfaces.Repositories
{
    public interface IProductRepository
    {
        void Create(Product product);
    }
}
