using Marketplace.Domain.Entities;
using System;

namespace Marketplace.App.Handlers.Items
{
    public class CreateItemResponse
    {
        public string Name { get; set; }
        public Guid IdItem { get; set; }

        public static explicit operator CreateItemResponse(Item i) =>
            new CreateItemResponse
            {
                IdItem = i.Id,
                Name = i.Name
            };
    }
}
