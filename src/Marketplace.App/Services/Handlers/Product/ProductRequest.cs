using MediatR;

namespace Marketplace.App.Services.Handlers.Product
{
    public class ProductRequest : IRequest<ProductResponse>
    {
        public string Name { get; set; }
    }
}
