using Marketplace.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Marketplace.Domain.Interfaces.Repositories
{
    public interface IProductRepository
    {
        void Create(Product product);
        Task<Product> CreateAsync(Product product);
        Task<Product> GetByIdAsync(Guid idProduct);
    }
}
