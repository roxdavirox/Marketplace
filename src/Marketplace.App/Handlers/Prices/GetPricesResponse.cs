using Marketplace.Domain.Entities;
using System.Collections.Generic;

namespace Marketplace.App.Handlers.Prices
{
    public class _Price
    {
        public int Start { get; set; }
        public int End { get; set; }
        public decimal Value { get; set; }
    }

    public class GetPricesResponse
    {
        public List<_Price> Prices { get; set; }

        public GetPricesResponse(IEnumerable<Price> prices)
        {
            if (prices == null) return;

            Prices = new List<_Price>();

            foreach (var price in prices)
            {
                Prices.Add(new _Price
                {
                    Start = price.Start,
                    End = price.End,
                    Value = price.Value
                });
            }
        }
    }
}
