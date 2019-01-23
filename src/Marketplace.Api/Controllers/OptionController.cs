using Marketplace.App.Services.Handlers.Options;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Marketplace.Api.Controllers
{
    [ApiController]
    public class OptionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OptionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("api/Products/{idProduct:Guid}/Options")]
        public async Task<CreateOptionResponse> Post(CreateOptionProductRequest request, Guid idProduct)
        {
            var command = new CreateOptionProductRequest(request, idProduct);
            return await _mediator.Send(command);
        }

        [HttpPost("api/Options")]
        public async Task<CreateOptionResponse> Post(CreateOptionRequest request) =>
            await _mediator.Send(request);

        [HttpPut("api/Options/Items")]
        public async Task<PutOptionItemResponse> Put(PutOptionItemRequest request) =>
            await _mediator.Send(request);
        
    }
}
