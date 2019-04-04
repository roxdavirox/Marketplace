using MediatR;
using System;

namespace Marketplace.App.Handlers.Items
{
    public class CreateItemOptionRequest : IRequest<CreateItemResponse>
    {
        public CreateItemOptionRequest(CreateItemOptionRequest request, Guid idOption)
        {
            IdOption = idOption;
            ItemName = request.ItemName;
        }

        public CreateItemOptionRequest() { }

        internal Guid IdOption { get; set; }
        public string ItemName { get; set; }
    }
}
