using MediatR;

namespace Marketplace.App.Services.Handlers.Items
{
    public class CreateItemRequest : IRequest<CreateItemResponse>
    {
        public string Name { get; set; }
    }
}
