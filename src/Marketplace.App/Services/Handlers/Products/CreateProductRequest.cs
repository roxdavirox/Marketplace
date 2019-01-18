using MediatR;

namespace Marketplace.App.Services.Handlers.Products
{
    public class CreateProductRequest : IRequest<CreateProductResponse>
    {
        public string Name { get; set; }
    }
}
