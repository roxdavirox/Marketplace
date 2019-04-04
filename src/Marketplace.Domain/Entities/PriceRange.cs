using Marketplace.Domain.Entities.Base;
using Marketplace.Domain.Validators;
using System.Collections.Generic;

namespace Marketplace.Domain.Entities
{
    public class PriceRange : EntityBase
    {
        public string Name { get; private set; }

        public virtual IEnumerable<Item> Items { get; private set; }
        public IEnumerable<Price> Prices { get; private set; }

        public PriceRange(string name)
        {
            Name = name;

            Validate(this, new PriceRangeValidator());
        }

        public void HasMany(IEnumerable<Price> prices) => Prices = prices;
    }
}
