using System;
using Marketplace.Domain.Entities;

namespace Marketplace.App.Handlers.Products
{
  public class CreateFullProductResponse {
    public string ProductName { get; set; }
    public Guid Id { get; set; }

     public static explicit operator CreateFullProductResponse(Product p) =>
      new CreateFullProductResponse() {
        ProductName = p.Name,
        Id = p.Id
      };
  }
}