using MediatR;

namespace Marketplace.App.Handlers.Options
{
    public class CreateOptionRequest : IRequest<CreateOptionResponse> 
    {
        public string Name { get; set; }
    }
}
