using Marketplace.Domain.Entities;
using System;

namespace Marketplace.App.Handlers.Products
{
    public class CreateProductResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public static explicit operator CreateProductResponse(Product p) =>
            new CreateProductResponse
            {
                Id = p.Id,
                Name = p.Name
            };
    }
}
