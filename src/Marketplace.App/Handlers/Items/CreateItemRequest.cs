using MediatR;

namespace Marketplace.App.Handlers.Items
{
    public class CreateItemRequest : IRequest<CreateItemResponse>
    {
        public string Name { get; set; }
    }
}
