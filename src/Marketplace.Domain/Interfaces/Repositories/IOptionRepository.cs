using Marketplace.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Marketplace.Domain.Interfaces.Repositories
{
    public interface IOptionRepository
    {
        Task<Option> CreateAsync(Option option);
        Task<Option> GetByIdAsync(Guid idOption);
    }
}
