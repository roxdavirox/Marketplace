using MediatR;
using System;
using System.Collections.Generic;

namespace Marketplace.App.Handlers.PricesRange
{
    public class DeletePricesRangeRequest : IRequest<DeletePricesRangeResponse>
    {
        public IEnumerable<Guid> PricesRangesIds { get; set; }
    }
}
