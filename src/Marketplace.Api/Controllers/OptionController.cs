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
        public async Task<CreateOptionResponse> Post(CreateProductOptionRequest request, Guid idProduct)
        {
            var command = new CreateProductOptionRequest(request, idProduct);
            return await _mediator.Send(command);
        }

        [HttpPost("api/Options")]
        public async Task<CreateOptionResponse> Post(CreateOptionRequest request) =>
            await _mediator.Send(request);

    }
}
