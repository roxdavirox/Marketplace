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

        public Item(string name, PriceInterval priceInterval)
        {
            Name = name;
            PriceInterval = priceInterval;

            Validate(this, new ItemValidator());
        }

        public Item(string name, Option option)
        {
            Name = name;

            Validate(this, new ItemValidator());
        }

        public string Name { get; set; }
        public PriceInterval PriceInterval { get; private set; }
        public virtual Option Option { get; set; }

        public void AssociateWith(Option option)
        {
            Option = option;
        }
    }
}
