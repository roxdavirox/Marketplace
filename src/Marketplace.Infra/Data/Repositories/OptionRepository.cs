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
    public class OptionRepository : IOptionRepository
    {
        private readonly MarketplaceContext _context;

        public OptionRepository(MarketplaceContext context)
        {
            _context = context;
        }

        public async Task<Option> CreateAsync(Option option)
        {
            await _context.Options.AddAsync(option);
            return option;
        }

        public async Task CreateRangeAsync(IEnumerable<Option> options) =>
            await _context.Options.AddRangeAsync(options);

        public async Task<IEnumerable<Option>> GetByIdsAsync(IEnumerable<Guid> optionsIds)
        {
            var options = _context.Options.Where(o => optionsIds.Contains(o.Id));

            return await options.ToListAsync();
        }

        public async Task<int> RemoveRange(IEnumerable<Option> options)
        {
            _context.Options.RemoveRange(options);

            var deletedOptions = options.Count();

            return await Task.FromResult<int>(deletedOptions);
        }
            
        public async Task<Option> GetByIdAsync(Guid idOption)
        {
            var option = await _context.Options.FindAsync(idOption);
            return option;
        }

        public async Task<IEnumerable<Option>> GetAllAsync() => 
            await _context.Options.ToListAsync();
    }
}
