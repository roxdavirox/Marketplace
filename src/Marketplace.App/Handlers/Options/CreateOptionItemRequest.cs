using MediatR;
using System;

namespace Marketplace.App.Handlers.Options
{
    public class CreateOptionItemRequest : IRequest<CreateOptionItemResponse>
    {
        public string Name { get; set; }
        internal Guid IdItem { get; set; }

        public CreateOptionItemRequest() { }

        public CreateOptionItemRequest(CreateOptionItemRequest request, Guid idItem)
        {
            Name = request.Name;
            IdItem = idItem;
        }
    }
}
