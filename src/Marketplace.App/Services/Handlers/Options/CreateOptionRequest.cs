using MediatR;
using System;

namespace Marketplace.App.Services.Handlers.Options
{
    public class CreateOptionRequest : IRequest<CreateOptionResponse>
    {
        public Guid IdProduct { get; set; }
        public string Name { get; set; }
    }
}
