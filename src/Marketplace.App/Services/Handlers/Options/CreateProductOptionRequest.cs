using MediatR;
using System;

namespace Marketplace.App.Services.Handlers.Options
{
    public class CreateProductOptionRequest : IRequest<CreateOptionResponse>
    {
        internal Guid IdProduct { get; private set; }
        public string Name { get; set; }

        public CreateProductOptionRequest()
        {

        }

        public CreateProductOptionRequest(CreateProductOptionRequest request, Guid idProduct)
        {
            Name = request.Name;
            IdProduct = idProduct;
        }
    }
}
