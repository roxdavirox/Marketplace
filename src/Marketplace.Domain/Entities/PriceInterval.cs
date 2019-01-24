using Marketplace.Domain.Entities.Base;

namespace Marketplace.Domain.Entities
{
    public class PriceInterval : EntityBase
    {
        public PriceInterval(decimal value)
        {
            Value = value;
            Start = End = 0;
        }

        public PriceInterval(int start, int end, decimal value)
        {
            Start = start;
            End = end;
            Value = value;
        }

        public int Start { get; private set; }
        public int End { get; private set; }
        public decimal Value { get; private set; }
    }
}
