using MediatR;
using System;

namespace Marketplace.App.Handlers.Prices
{
    public class GetPricesRequest : IRequest<GetPricesResponse>
    {
        public GetPricesRequest(Guid idPriceRange)
        {
            IdPriceRange = idPriceRange;
        }

        public Guid IdPriceRange { get; set; }
    }
}
