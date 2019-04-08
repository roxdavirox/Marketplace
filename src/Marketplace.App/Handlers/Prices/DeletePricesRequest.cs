using System;
using System.Collections.Generic;
using MediatR;

namespace Marketplace.App.Handlers.Prices {
  public class DeletePricesRequest : IRequest<DeletePricesResponse> {
    public DeletePricesRequest(IEnumerable<Guid> pricesIds)
    {
      PricesIds = pricesIds;
    }

    public IEnumerable<Guid> PricesIds { get; set; }
  }
}