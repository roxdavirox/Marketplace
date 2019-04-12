using System;
using MediatR;

namespace Marketplace.App.Handlers.Items {
  public class RemovePriceRangeRequest : IRequest<RemovePriceRangeResponse> {
    public RemovePriceRangeRequest(Guid idItem)
    {
      IdItem = idItem;
    }

    public Guid IdItem { get; set; }
  }
}