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

        public Option(string name, Product product)
        {
            Name = name;
            Product = product;

            Validate(this, new OptionValidator());
        }

        public string Name { get; set; }
        public IEnumerable<Item> Items { get; set; }
        public virtual Product Product { get; set; }

        public void AssociateWith(Product product)
        {
            Product = product;
        }

        public Option AddItems(IEnumerable<Item> items) {
            Items = items;
            return this;
        }
    }
}
