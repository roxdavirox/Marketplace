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

        /// <summary>
        /// Cria um novo Produto no sistema
        /// </summary>
        /// <param name="request">Request com o Nome do Produto</param>
        /// <returns>Retorna o Nome e Id do Produto criado</returns>
        [HttpPost("api/Products"), AllowAnonymous]
        public async Task<CreateProductResponse> Post(CreateProductRequest request) =>
            await _mediator.Send(request);

        /// <summary>
        /// Associa uma opção existente a um Produto existente
        /// </summary>
        /// <param name="request">Request com Id do Produto e Opção existente</param>
        /// <returns>Retorna os Ids e Nomes do Produto e Opção associados</returns>
        [HttpPut("api/Products/Options"), AllowAnonymous]
        public async Task<PutProductOptionResponse> Put(PutProductOptionRequest request) =>
            await _mediator.Send(request);
    }
}
