using Marketplace.Domain.Entities.Base;
using Marketplace.Domain.Validators;

namespace Marketplace.Domain.Entities
{
    public class Price : EntityBase
    {
        public Price(PriceRange priceRange, int start = 1, int end = int.MaxValue, decimal value = 0)
        {
            PriceRange = priceRange;
            Start = start;
            End = end;
            Value = value;

            Validate(this, new PriceValidator());
        }

        public Price()
        {
            Index = 0;
            Start = 1;
            End = int.MaxValue;
            Value = 0;

            Validate(this, new PriceValidator());
        }

        public int Index { get; private set; }
        public int Start { get; private set; }
        public int End { get; private set; }
        public decimal Value { get; private set; }
        public virtual PriceRange PriceRange { get; private set; }

        public void AssociateWith(PriceRange priceRange)
        {
            PriceRange = priceRange;
        }
    }
}
