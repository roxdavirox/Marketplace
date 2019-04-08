using System;
using System.Collections.Generic;

namespace Marketplace.App.Handlers.Prices {
  public class DeletePricesResponse {
    public DeletePricesResponse(int deletedPrices)
    {
      DeletedPrices = deletedPrices;
    }

    public int DeletedPrices { get; set; }
  }
}