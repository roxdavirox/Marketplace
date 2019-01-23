using Marketplace.App.Services.Handlers.Products;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Marketplace.Api.Controllers
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("api/Products")]
        public async Task<CreateProductResponse> Post(CreateProductRequest request) =>
            await _mediator.Send(request);

        [HttpPut("api/Products/Options")]
        public async Task<PutProductOptionResponse> Put(PutProductOptionRequest request) =>
            await _mediator.Send(request);
    }
}
