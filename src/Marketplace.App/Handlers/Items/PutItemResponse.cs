using Marketplace.Domain.Entities;
using System;

namespace Marketplace.App.Handlers.Items
{
    public class PutItemResponse
    {
        public Guid IdPriceRange { get; set; }
        public Guid IdItem { get; set; }
        public string Name { get; set; }

        public PutItemResponse(PriceRange priceRange, Item item)
        {
            IdPriceRange = priceRange.Id;

            IdItem = item.Id;
            Name = item.Name;
        }
    }
}
