using Marketplace.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Marketplace.App.Handlers.Prices
{
    public class _Price
    {
        public Guid IdPrice { get; set;}
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
                    IdPrice = price.Id,
                    Start = price.Start,
                    End = price.End,
                    Value = price.Value
                });
            }
        }
    }
}
