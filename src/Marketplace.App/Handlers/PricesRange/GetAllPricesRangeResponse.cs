using Marketplace.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Marketplace.App.Handlers.PricesRange
{
    public class _AllPricesRange
    {
        public Guid IdPriceRange { get; set; }
        public string Name { get; set; }
    }

    public class GetAllPricesRangeResponse
    {
        public List<_AllPricesRange> PricesRange;

        public GetAllPricesRangeResponse(IEnumerable<PriceRange> pricesRange)
        {
            PricesRange = new List<_AllPricesRange>();

            if (pricesRange == null) return;

            foreach (var priceRange in pricesRange)
            {
                PricesRange.Add(new _AllPricesRange
                {
                    IdPriceRange = priceRange.Id,
                    Name = priceRange.Name
                });
            }
        }

    }
}
