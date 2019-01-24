using MediatR;
using System.Collections.Generic;

namespace Marketplace.App.Services.Handlers.Items
{
    public class CreateItemRequest : IRequest<CreateItemResponse>
    {
        public string Name { get; set; }

        public bool Fixed { get; set; }

        public class _FixedPrice
        {
            public decimal Value { get; set; }
        }

        public _FixedPrice FixedPrice { get; set; }

        public class _RelativePrice
        {
            public class _Interval
            {
                public int Start { get; set; }
                public int End { get; set; }
                public decimal Value { get; set; }
            }

            public IEnumerable<_Interval> Table { get; set; }
        }

        public _RelativePrice RelativePrice { get; set; }

    }
}
