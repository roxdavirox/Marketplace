using Marketplace.Domain.Entities.Base;
using Marketplace.Domain.Validators;
using System.Collections.Generic;

namespace Marketplace.Domain.Entities
{
    public class Option : EntityBase
    {
        public Option(string name)
        {
            Name = name;

            Validate(this, new OptionValidator());
        }
        
        public string Name { get; set; }
        public IEnumerable<Item> Items { get; set; }
        public virtual IEnumerable<Product> Products { get; set; }
        
        public Option HasMany(IEnumerable<Item> items) {
            Items = items;
            return this;
        }

        public void RemoveItems() => Items = null;
    }
}
