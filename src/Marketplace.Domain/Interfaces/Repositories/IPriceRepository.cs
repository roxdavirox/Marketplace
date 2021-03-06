﻿using Marketplace.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Marketplace.Domain.Interfaces.Repositories
{
    public interface IPriceRepository
    {
        Task CreateRangeAsync(IEnumerable<Price> prices);
        Task<Price> CreateAsync(Price price);
        Task<IEnumerable<Price>> GetPricesByPriceRangeIdAsync(Guid idPriceRange);
        Task<int> RemoveRangeAsync(IEnumerable<Price> prices);
        Task<IEnumerable<Price>> GetByIdsAsync(IEnumerable<Guid> pricesIds);
    }
}
