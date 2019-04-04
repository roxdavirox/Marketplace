using Marketplace.Domain.Entities;
using System;

namespace Marketplace.App.Handlers.PricesRange
{
    public class CreatePriceRangeResponse
    {
        public string Name { get; set; }
        public Guid IdPriceRange { get; set; }

        public static explicit operator CreatePriceRangeResponse(PriceRange pr) =>
            new CreatePriceRangeResponse
            {
               IdPriceRange = pr.Id,
               Name = pr.Name
            };
    }
}
