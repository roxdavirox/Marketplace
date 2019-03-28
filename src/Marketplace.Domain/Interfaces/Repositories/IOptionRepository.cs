using Marketplace.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Marketplace.Domain.Interfaces.Repositories
{
    public interface IOptionRepository
    {
        Task<Option> CreateAsync(Option option);
        Task CreateRangeAsync(IEnumerable<Option> options);
        Task<IEnumerable<Option>> GetByIdsAsync(IEnumerable<Guid> optionsIds);
        Task<int> RemoveRange(IEnumerable<Option> options);
        Task<IEnumerable<Option>> GetAllAsync();
        Task<Option> GetByIdAsync(Guid idOption);
    }
}
