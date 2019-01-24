using Marketplace.Domain.Entities.Base;

namespace Marketplace.Domain.Entities
{
    public class Price : EntityBase
    {
        public Price(bool @fixed, decimal value)
        {
            Fixed = @fixed;
            Value = value;
        }

        public Price()
        {
            Fixed = false;
            Value = 0;
        }

        public Price(bool @fixed)
        {
            Fixed = @fixed;
        }

        public Price(RelativePrice prices)
        {
            Prices = prices;
        }

        public bool Fixed { get; private set; }
        public decimal Value { get; private set; }
        public RelativePrice Prices { get; set; }
    }
}
