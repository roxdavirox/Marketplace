using MediatR;
using System;

namespace Marketplace.App.Handlers.Prices
{
    public class CreatePriceRequest : IRequest<CreatePriceResponse>
    {
        public CreatePriceRequest(CreatePriceRequest request, Guid idPriceRange)
        {
            IdPriceRange = idPriceRange;
            Start = request.Start;
            End = request.End;
            Value = request.Value;
        }

        public CreatePriceRequest() { }

        public Guid IdPriceRange { get; private set; }
        public int Start { get; set; }
        public int End { get; set; }
        public decimal Value { get; set; }
    }
}
