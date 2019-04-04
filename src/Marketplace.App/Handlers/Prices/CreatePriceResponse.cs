using System;

namespace Marketplace.App.Handlers.Prices
{
    public class CreatePriceResponse
    {
        public CreatePriceResponse(Guid idPrice, Guid idPriceRange)
        {
            IdPrice = idPrice;
            IdPriceRange = idPriceRange;
        }

        public Guid IdPrice { get; set; }
        public Guid IdPriceRange { get; set; }
    }
}
