using System;

namespace Marketplace.App.Handlers.Items {
  public class RemovePriceRangeResponse {
    public RemovePriceRangeResponse(Guid idItem)
    {
      IdItem = idItem;
    }

    public Guid IdItem { get; set;}
  }
}