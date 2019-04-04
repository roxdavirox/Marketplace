using MediatR;
using System.Collections.Generic;

namespace Marketplace.App.Handlers.PricesRange
{
    public class CreatePriceRangeRequest : IRequest<CreatePriceRangeResponse>
    {
        public string Name { get; set; }

        public class _PriceRange
        {
            public int Start { get; set; }
            public int End { get; set; }
            public decimal Value { get; set; }
        }

        public IEnumerable<_PriceRange> Prices { get; set; }
    }
}
