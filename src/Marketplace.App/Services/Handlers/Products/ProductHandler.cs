using Marketplace.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Marketplace.App.Services.Handlers.Products
{
    public class ProductHandler : IRequestHandler<CreateProductRequest, CreateProductResponse>
    {
        public Task<CreateProductResponse> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            if (request == null) return null;

            var product = new Product(request.Name);

            var response = (CreateProductResponse) product;

            return Task.FromResult(response);
        }
    }
}
