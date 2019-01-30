﻿using Marketplace.Domain.Entities.Base;
using System.Collections.Generic;

namespace Marketplace.Domain.Entities
{
    public class PriceRange : EntityBase
    {
        public IEnumerable<Price> Prices { get; private set; }
        public virtual Item Item { get; private set; }
    }
}