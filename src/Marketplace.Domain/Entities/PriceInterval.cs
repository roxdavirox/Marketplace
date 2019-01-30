using Marketplace.Domain.Entities.Base;
using System.Collections.Generic;

namespace Marketplace.Domain.Entities
{
    public class PriceInterval : EntityBase
    {
        public IEnumerable<Price> Prices { get; private set; }
    }
}
