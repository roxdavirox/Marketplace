using MediatR;
using System;
using System.Collections.Generic;

namespace Marketplace.App.Handlers.Options
{
    public class DeleteOptionsRequest : IRequest<DeleteOptionsResponse>
    {
        public IEnumerable<Guid> OptionsIds { get; set; }
    }
}
