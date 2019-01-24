using Marketplace.Domain.Entities.Base;
using System.Collections.Generic;

namespace Marketplace.Domain.Entities
{
    public class RelativePrice : EntityBase
    {
        public RelativePrice(IEnumerable<PriceInterval> intervals)
        {
            Intervals = intervals;
        }
        
        public IEnumerable<PriceInterval> Intervals { get; private set; }
    }
}
