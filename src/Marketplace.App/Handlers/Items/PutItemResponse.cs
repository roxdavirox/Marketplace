using Marketplace.Domain.Entities;
using System;

namespace Marketplace.App.Handlers.Items
{
    public class PutItemResponse
    {
        public Guid IdPriceRange { get; set; }
        public string PriceRangeName { get; set; }

        public Guid IdItem { get; set; }
        public string ItemName { get; set; }

        public PutItemResponse(PriceRange priceRange, Item item)
        {
            IdPriceRange = priceRange.Id;
            PriceRangeName = priceRange.Name;

            IdItem = item.Id;
            ItemName = item.Name;
        }
    }
}
