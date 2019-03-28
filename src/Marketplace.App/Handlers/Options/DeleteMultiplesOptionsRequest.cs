using MediatR;
using System;
using System.Collections.Generic;

namespace Marketplace.App.Handlers.Options
{
    public class DeleteMultiplesOptionsRequest : IRequest<DeleteMultiplesOptionsResponse>
    {
        public IEnumerable<Guid> OptionsIds { get; set; }
    }
}
