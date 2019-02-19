using MediatR;
using System.Collections.Generic;

namespace Marketplace.App.Handlers.Products
{
    public class CreateFullProductRequest : IRequest<CreateFullProductResponse>
    {
        public string Name { get; set; }
        public IEnumerable<CreateFullProductRequest_Option> Options { get; set; }
        public class CreateFullProductRequest_Option
        {
            public string Name { get; set; }
            public IEnumerable<CreateFullProductRequest_Item> Items { get; set; }
            public class CreateFullProductRequest_Item
            {
                public string Name { get; set; }
                public IEnumerable<CreateFullProductRequest_Price> Prices { get; set; }
                public class CreateFullProductRequest_Price
                {
                    public int Start { get; set; }
                    public int End { get; set; }
                    public decimal Value { get; set; }
                }
            }
        }
    }
}