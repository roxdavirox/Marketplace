using Marketplace.App.Handlers.Options;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Marketplace.Api.Controllers
{
    [ApiController, Authorize(Roles = "Adm")]
    public class OptionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OptionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("api/Products/{idProduct:Guid}/Options"), AllowAnonymous]
        public async Task<CreateOptionResponse> Post(CreateOptionProductRequest request, Guid idProduct)
        {
            var command = new CreateOptionProductRequest(request, idProduct);
            return await _mediator.Send(command);
        }

        [HttpPost("api/Options"), AllowAnonymous]
        public async Task<CreateOptionResponse> Post(CreateOptionRequest request) =>
            await _mediator.Send(request);

        [HttpPut("api/Options/Items")]
        public async Task<PutOptionItemResponse> Put(PutOptionItemRequest request) =>
            await _mediator.Send(request);

        [HttpPost("api/Items/{idItem:Guid}/Options"), AllowAnonymous]
        public async Task<CreateOptionItemResponse> Post(CreateOptionItemRequest request, Guid idItem)
        {
            var command = new CreateOptionItemRequest(request, idItem);

            var response = await _mediator.Send(command);

            return response;
        }

        [HttpGet("api/Options"), AllowAnonymous]
        public async Task<GetAllOptionsResponse> GetAll() =>
            await _mediator.Send(new GetAllOptionsRequest());

        [HttpDelete("api/Options"), AllowAnonymous]
        public async Task<DeleteMultiplesOptionsResponse> DeleteMultiples(
                DeleteMultiplesOptionsRequest request
            ) => await _mediator.Send(request);
    }
}
