using Marketplace.App.Services.Handlers.Options;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Marketplace.Api.Controllers
{
    [Route("api/[Controller]s")]
    [ApiController]
    public class OptionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OptionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("api/Products/{idProduct:Guid}/Options")]
        public async Task<CreateOptionResponse> Post(CreateOptionRequest request, Guid idProduct)
        {
            request.HasRelationshipWith(idProduct);
            return await _mediator.Send(request);
        }

    }
}
