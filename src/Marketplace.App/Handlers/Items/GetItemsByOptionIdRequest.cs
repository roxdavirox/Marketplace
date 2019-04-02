using MediatR;
using System;

namespace Marketplace.App.Handlers.Items
{
    public class GetItemsByOptionIdRequest : IRequest<GetItemsByOptionIdResponse>
    {
        public Guid IdOption { get; set; }
        public GetItemsByOptionIdRequest(Guid idOption)
        {
            IdOption = idOption;
        }
    }
}
