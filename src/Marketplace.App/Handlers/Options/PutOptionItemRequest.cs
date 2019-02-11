using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Marketplace.App.Handlers.Options
{
    public class PutOptionItemRequest : IRequest<PutOptionItemResponse>
    {
        public Guid IdOption { get; set; }
        public Guid IdItem { get; set; }
    }
}
