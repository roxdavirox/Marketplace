using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Marketplace.App.Handlers.Items
{
    public class PutItemRequest : IRequest<PutItemResponse>
    {
        public Guid IdPriceRange { get; set; }
        public Guid IdItem { get; set; }
    }
}
