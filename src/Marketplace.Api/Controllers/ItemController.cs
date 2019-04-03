using Marketplace.App.Handlers.Items;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Marketplace.Api.Controllers
{
    [ApiController, Authorize(Roles = "Adm")]
    public class ItemController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ItemController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("api/Items"), AllowAnonymous]
        public async Task<CreateItemResponse> Post(CreateItemRequest request) =>
            await _mediator.Send(request);

        [HttpPost("api/Options/{idOption}/Items"), AllowAnonymous]
        public async Task<CreateItemResponse> Post(CreateItemOptionRequest request, Guid idOption)
        {
            var command = new CreateItemOptionRequest(request, idOption);
            var response = await _mediator.Send(command);
            return response;
        }

        [HttpGet("api/Items/{idOption}"), AllowAnonymous]
        public async Task<GetItemsByOptionIdResponse> GetByOptionId(Guid idOption) =>
            await _mediator.Send( new GetItemsByOptionIdRequest(idOption));

        [HttpDelete("api/Items"), AllowAnonymous]
        public async Task<DeleteMultipleItemsResponse> DeleteMultiples(
                DeleteMultiplesItemsRequest request
            ) => await _mediator.Send(request);
    }
}
