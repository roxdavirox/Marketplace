using Marketplace.Domain.Entities.Base;
using Marketplace.Domain.Validators;
using System.Collections.Generic;

namespace Marketplace.Domain.Entities
{
    public class PriceRange : EntityBase
    {
        public virtual ICollection<Item> Items { get; private set; }
        public ICollection<Price> Prices { get; private set; }

        public PriceRange() { Validate(this, new PriceRangeValidator()); }

    }
}
