using System;
using Marketplace.Domain.Entities;

namespace Marketplace.App.Handlers.Items {
  public class RemovePriceRangeResponse {
    public RemovePriceRangeResponse(Item item)
    {
      IdItem = item.Id;
      Name = item.Name;
      IdPriceRange = null;
    }

    public Guid IdItem { get; set;}
    public string Name { get; set; }
    public Guid? IdPriceRange { get; set; }
  }
}