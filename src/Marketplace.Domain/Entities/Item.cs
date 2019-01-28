using Marketplace.Domain.Entities.Base;
using Marketplace.Domain.Validators;
using System.Collections.Generic;

namespace Marketplace.Domain.Entities
{
    public class Item : EntityBase
    {
        public Item(string name)
        {
            Name = name;

            Validate(this, new ItemValidator());
        }

        public Item(string name, IEnumerable<Price> prices)
        {
            Name = name;
            Prices = prices;

            Validate(this, new ItemValidator());
        }

        public Item(string name, IEnumerable<Price> prices, Option option)
        {
            Name = name;
            Prices = prices;
            Option = option;

            Validate(this, new ItemValidator());
        }

        public string Name { get; set; }
        public IEnumerable<Price> Prices { get; set; }
        public virtual Option Option { get; set; }

        public void AssociateWith(Option option)
        {
            Option = option;
        }
    }
}
