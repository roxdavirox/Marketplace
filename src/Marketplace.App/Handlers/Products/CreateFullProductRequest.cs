using MediatR;
using System.Collections.Generic;

namespace Marketplace.App.Handlers.Products {
  public class CreateFullProductRequest : IRequest<CreateFullProductResponse> {
    public string Name { get; set; }
    public IEnumerable<_Options> Options { get; set; }
    public class _Options {
      public string Name { get; set; }
      public IEnumerable<_Item> Items { get; set; }
      public class _Item {
      public string Name { get; set; }
      public IEnumerable<_Price> Prices { get; set; }
      public class _Price {
        public int Start { get; set; }
        public int End { get; set; }
        public decimal Value { get; set; }
      }
     }
   }
 }
}