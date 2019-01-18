using Marketplace.Domain.Entities;
using Marketplace.Domain.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Marketplace.App.Services.Handlers.Products
{
    public class CreateProductHandler : IRequestHandler<CreateProductRequest, CreateProductResponse>
    {
        private readonly IProductRepository _repository;

        public CreateProductHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public Task<CreateProductResponse> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            if (request == null) return null;

            var product = new Product(request.Name);

            _repository.Create(product);

            var response = (CreateProductResponse) product;

            return Task.FromResult(response);
        }
    }
}
