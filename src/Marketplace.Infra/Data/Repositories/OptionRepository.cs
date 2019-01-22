﻿using Marketplace.Domain.Entities;
using Marketplace.Domain.Interfaces.Repositories;
using Marketplace.Infra.Data.EF.Context;
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
    }
}