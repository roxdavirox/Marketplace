using MediatR;

namespace Marketplace.App.Handlers.PricesRange
{
    public class CreatePriceRangeRequest : IRequest<CreatePriceRangeResponse>
    {
        public string Name { get; set; }
    }
}
