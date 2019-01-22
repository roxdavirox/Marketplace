using MediatR;

namespace Marketplace.App.Services.Handlers.Options
{
    public class CreateOptionRequest : IRequest<CreateOptionResponse> 
    {
        public string Name { get; set; }
    }
}
