using MediatR;
using System;

namespace Marketplace.App.Handlers.Prices
{
    public class GetPricesRequest : IRequest<GetPricesResponse>
    {
        public Guid IdPriceRange { get; set; }
    }
}
