using Marketplace.App.Services.Handlers.Items;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Marketplace.Api.Controllers
{
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ItemController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("api/Items")]
        public async Task<CreateItemResponse> Post(CreateItemRequest request) =>
            await _mediator.Send(request);
    }
}
