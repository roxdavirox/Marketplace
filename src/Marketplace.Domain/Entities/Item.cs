using Marketplace.Domain.Entities.Base;
using Marketplace.Domain.Validators;

namespace Marketplace.Domain.Entities
{
    public class Item : EntityBase
    {
        public Item(string name)
        {
            Name = name;

            Validate(this, new ItemValidator());
        }

        public Item(string name, PriceRange priceRange)
        {
            Name = name;
            PriceRange = priceRange;

            Validate(this, new ItemValidator());
        }

        public Item(string name, Option option)
        {
            Name = name;

            Validate(this, new ItemValidator());
        }

        public string Name { get; set; }
        public PriceRange PriceRange { get; private set; }
        public virtual Option Option { get; set; }

        public void HasOne(Option option)
        {
            Option = option;
        }

        public void HasOne(PriceRange priceRange)
        {
            PriceRange = priceRange;
        }

        public void RemovePriceRange() => PriceRange = null;
    }
}
