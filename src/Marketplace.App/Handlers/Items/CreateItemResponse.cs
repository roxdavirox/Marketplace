using Marketplace.Domain.Entities;
using System;

namespace Marketplace.App.Handlers.Items
{
    public class CreateItemResponse
    {
        public string Name { get; set; }
        public Guid Id { get; set; }

        public static explicit operator CreateItemResponse(Item i) =>
            new CreateItemResponse
            {
                Id = i.Id,
                Name = i.Name
            };
    }
}
