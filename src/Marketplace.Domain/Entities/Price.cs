﻿using Marketplace.Domain.Entities.Base;
using Marketplace.Domain.Validators;

namespace Marketplace.Domain.Entities
{
    public class Price : EntityBase
    {
        public Price(Item item, int start = 1, int end = int.MaxValue, decimal value = 0)
        {
            Item = item;
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
        public virtual Item Item { get; private set; }
    }
}
