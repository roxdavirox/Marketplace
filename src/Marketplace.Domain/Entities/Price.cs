using Marketplace.Domain.Entities.Base;

namespace Marketplace.Domain.Entities
{
    public class Price : EntityBase
    {
        public Price(int start, int end, decimal value)
        {
            Start = start;
            End = end;
            Value = value;
        }

        public Price()
        {
            Start = 1;
            End = int.MaxValue;
            Value = 0;
        }

        public int Index { get; private set; }
        public int Start { get; private set; }
        public int End { get; private set; }
        public decimal Value { get; private set; }
        public virtual Item Item { get; private set; }

    }
}
