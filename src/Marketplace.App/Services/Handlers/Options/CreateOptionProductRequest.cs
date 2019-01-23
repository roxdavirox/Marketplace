using MediatR;
using System;

namespace Marketplace.App.Services.Handlers.Options
{
    public class CreateOptionProductRequest : IRequest<CreateOptionResponse>
    {
        internal Guid IdProduct { get; private set; }
        public string Name { get; set; }

        public CreateOptionProductRequest()
        {

        }

        public CreateOptionProductRequest(CreateOptionProductRequest request, Guid idProduct)
        {
            Name = request.Name;
            IdProduct = idProduct;
        }
    }
}
