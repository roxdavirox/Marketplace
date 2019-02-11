using Marketplace.Domain.Entities;
using System;

namespace Marketplace.App.Handlers.Products
{
    public class PutProductOptionResponse
    {
        public string ProductName { get; set; }
        public Guid IdProduct { get; set; }

        public string OptionName { get; set; }
        public Guid IdOption { get; set; }

        public PutProductOptionResponse(Product product, Option option)
        {
            ProductName = product.Name;
            IdProduct = product.Id;

            OptionName = option.Name;
            IdOption = option.Id;
        }
    }
}
