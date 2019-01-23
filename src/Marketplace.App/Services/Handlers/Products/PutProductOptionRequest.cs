using MediatR;
using System;

namespace Marketplace.App.Services.Handlers.Products
{
    public class PutProductOptionRequest : IRequest<PutProductOptionResponse>
    {
        public Guid IdProduct { get; set; }
        public Guid IdOption { get; set; }
    }
}
