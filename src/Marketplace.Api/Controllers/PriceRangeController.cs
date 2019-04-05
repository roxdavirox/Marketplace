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

        /// <summary>
        /// Cria uma nova Tabela de Preço no sistema
        /// </summary>
        /// <param name="request">Request com o Nome da Tabela de Preço</param>
        /// <returns>Retorna o Id e Nome da Tabela de Preço</returns>
        [HttpPost("api/PriceRange"), AllowAnonymous]
        public async Task<CreatePriceRangeResponse> Post(CreatePriceRangeRequest request) =>
            await _mediator.Send(request);

        /// <summary>
        /// Obtem todas as Tabelas de Preços existentes no sistema
        /// </summary>
        /// <returns>Retorna o Nome e Id de cada Tabela de Preço existente</returns>
        [HttpGet("api/PriceRange"), AllowAnonymous]
        public async Task<GetAllPricesRangeResponse> GetAll() =>
            await _mediator.Send(new GetAllPricesRangeRequest());

        /// <summary>
        /// Deleta uma ou mais Tabelas de Preço a partir de seus Ids
        /// </summary>
        /// <param name="request">Request com uma lista dos Ids das Tabelas de Preços que serão deletadas</param>
        /// <returns>Retorna a quantidade de Tabelas de Preço deletadas</returns>
        [HttpDelete("api/PriceRange"), AllowAnonymous]
        public async Task<DeletePricesRangeResponse> Delete(DeletePricesRangeRequest request) =>
            await _mediator.Send(request);
    }
}
