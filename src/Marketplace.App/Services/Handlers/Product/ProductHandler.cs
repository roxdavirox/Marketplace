using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Marketplace.App.Services.Handlers.Product
{
    public class ProductHandler : IRequestHandler<ProductRequest, ProductResponse>
    {
        public Task<ProductResponse> Handle(ProductRequest request, CancellationToken cancellationToken)
        {

            return Task.FromResult(new ProductResponse());
        }
    }
}
