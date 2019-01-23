using MediatR;
using System;

namespace Marketplace.App.Services.Handlers.Items
{
    public class CreateItemOptionRequest : IRequest<CreateItemResponse>
    {
        public CreateItemOptionRequest(CreateItemOptionRequest request, Guid idOption)
        {
            IdOption = idOption;
            Name = request.Name;
        }

        public CreateItemOptionRequest() { }

        internal Guid IdOption { get; set; }
        public string Name { get; set; }
    }
}
