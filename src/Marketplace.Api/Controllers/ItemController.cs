using Marketplace.App.Handlers.Items;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
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

        [HttpPost("api/Options/{idOption}/Items")]
        public async Task<CreateItemResponse> Post(CreateItemOptionRequest request, Guid idOption)
        {
            var command = new CreateItemOptionRequest(request, idOption);
            var response = await _mediator.Send(command);
            return response;
        }
    }
}
