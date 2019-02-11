using Marketplace.Domain.Entities;
using System;

namespace Marketplace.App.Handlers.Options
{
    public class CreateOptionResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public static explicit operator CreateOptionResponse(Option o) =>
            new CreateOptionResponse()
            {
                Id = o.Id,
                Name = o.Name
            };

    }
}
