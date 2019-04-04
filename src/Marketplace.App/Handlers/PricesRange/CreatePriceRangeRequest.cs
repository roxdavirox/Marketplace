using MediatR;
using System.Collections.Generic;

namespace Marketplace.App.Handlers.PricesRange
{
    public class CreatePriceRangeRequest : IRequest<CreatePriceRangeResponse>
    {
        public string Name { get; set; }
    }
}
