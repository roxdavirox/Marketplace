using MediatR;
using System.Collections.Generic;

namespace Marketplace.App.Handlers.Items
{
    public class CreateItemRequest : IRequest<CreateItemResponse>
    {
        public string Name { get; set; }

        public class _Price
        {
            public int Start { get; set; }
            public int End { get; set; }
            public decimal Value { get; set; }
        }

        public IEnumerable<_Price> Prices { get; set; }

    }
}
