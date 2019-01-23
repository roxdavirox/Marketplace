using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Marketplace.App.Services.Handlers.Options
{
    public class CreateOptionItemRequest : IRequest<CreateOptionItemResponse>
    {
        public string Name { get; set; }
        internal Guid IdItem { get; set; }

        public CreateOptionItemRequest(CreateOptionItemRequest request, Guid idItem)
        {
            Name = request.Name;
            IdItem = idItem;
        }
    }
}
