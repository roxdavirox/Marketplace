using Marketplace.App.Handlers.PricesRange;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Marketplace.Api.Controllers
{
    [ApiController]
    public class PriceRangeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PriceRangeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("api/PriceRange"), AllowAnonymous]
        public async Task<CreatePriceRangeResponse> Post(CreatePriceRangeRequest request) =>
            await _mediator.Send(request);

        [HttpGet("api/PriceRange"), AllowAnonymous]
        public async Task<GetAllPricesRangeResponse> GetAll() =>
            await _mediator.Send(new GetAllPricesRangeRequest());

        [HttpDelete("api/PriceRange"), AllowAnonymous]
        public async Task<DeletePricesRangeResponse> Delete(DeletePricesRangeRequest request) =>
            await _mediator.Send(request);
    }
}
