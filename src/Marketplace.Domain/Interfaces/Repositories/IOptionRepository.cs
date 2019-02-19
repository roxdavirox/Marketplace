﻿using Marketplace.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Marketplace.Domain.Interfaces.Repositories
{
    public interface IOptionRepository
    {
        Task<Option> CreateAsync(Option option);
        Task CreateRangeAsync(IEnumerable<Option> options);
        Task<Option> GetByIdAsync(Guid idOption);
    }
}
