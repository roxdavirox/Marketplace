using Marketplace.App.Handlers.Prices;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Marketplace.Api.Controllers
{
    [ApiController]
    public class PriceController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PriceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("api/Price/{idPriceRange:Guid}"), AllowAnonymous]
        public async Task<CreatePriceResponse> Post(CreatePriceRequest request, Guid idPriceRange) =>
            await _mediator.Send(new CreatePriceRequest(request, idPriceRange));

        [HttpGet("api/Price/{idPriceRange:Guid}"), AllowAnonymous]
        public async Task<GetPricesResponse> GetByPriceRangeId(Guid idPriceRange) =>
            await _mediator.Send(new GetPricesRequest(idPriceRange));
    }
}
