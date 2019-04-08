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

        /// <summary>
        /// Cria uma Preço dentro de uma Tabela de Preço
        /// </summary>
        /// <param name="request"> Request com Inicio e Fim associado com um Valor entre o intervalo</param>
        /// <param name="idPriceRange">Id da Tabela de Preço que o novo Preço será associado</param>
        /// <returns>Retorna o Id do Preço e da Tabela de Preço</returns>
        [HttpPost("api/Price/{idPriceRange:Guid}"), AllowAnonymous]
        public async Task<CreatePriceResponse> Post(CreatePriceRequest request, Guid idPriceRange) =>
            await _mediator.Send(new CreatePriceRequest(request, idPriceRange));

        /// <summary>
        /// Obtem todos os Preços associados a uma Tabela de Preço
        /// </summary>
        /// <param name="idPriceRange">Id da Tabela de Preço que será usada para buscar os Preços</param>
        /// <returns>Retorna Inicio,Fim e Valor do Preço</returns>
        [HttpGet("api/Price/{idPriceRange:Guid}"), AllowAnonymous]
        public async Task<GetPricesResponse> GetByPriceRangeId(Guid idPriceRange) =>
            await _mediator.Send(new GetPricesRequest(idPriceRange));

        [HttpDelete("api/Price"), AllowAnonymous]
        public async Task<DeletePricesResponse> Delete(DeletePricesRequest request) =>
            await _mediator.Send(request);
    }
}
