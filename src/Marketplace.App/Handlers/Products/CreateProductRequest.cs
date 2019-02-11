using MediatR;

namespace Marketplace.App.Handlers.Products
{
    public class CreateProductRequest : IRequest<CreateProductResponse>
    {
        public string Name { get; set; }
    }
}
