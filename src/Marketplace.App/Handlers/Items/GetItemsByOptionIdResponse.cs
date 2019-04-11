using Marketplace.Domain.Entities;
using Marketplace.Shared.Extensions;
using System;
using System.Collections.Generic;

namespace Marketplace.App.Handlers.Items
{
    public class _Item
    {
        public Guid IdItem { get; set; }
        public Guid? IdPriceRange { get; set; }
        public string Name { get; set; }
    }

    public class GetItemsByOptionIdResponse
    {
        public List<_Item> Items { get; set; }

        public GetItemsByOptionIdResponse(IEnumerable<Item> items)
        {
            if (items == null) return;

            Items = new List<_Item>();

            items.ForEach(i => 
                Items.Add(new _Item { 
                    IdItem = i.Id, 
                    Name = i.Name, 
                    IdPriceRange = i.PriceRange?.Id 
                })
            );
        }
    }
}
