using Marketplace.App.Handlers.Products;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Marketplace.Api.Controllers
{
    [ApiController, Authorize(Roles = "Adm")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("api/Products"), AllowAnonymous]
        public async Task<CreateProductResponse> Post(CreateProductRequest request) =>
            await _mediator.Send(request);

        [HttpPut("api/Products/Options"), AllowAnonymous]
        public async Task<PutProductOptionResponse> Put(PutProductOptionRequest request) =>
            await _mediator.Send(request);
    }
}
