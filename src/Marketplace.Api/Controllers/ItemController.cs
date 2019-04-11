using Marketplace.App.Handlers.Items;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Marketplace.Api.Controllers
{
    [ApiController, Authorize(Roles = "Adm")]
    public class ItemController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ItemController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Criar um Item no sistema
        /// </summary>
        /// <param name="request">Request com Nome do Item</param>
        /// <returns>Retorna o Nome e o Id do Item</returns>
        [HttpPost("api/Items"), AllowAnonymous]
        public async Task<CreateItemResponse> Post(CreateItemRequest request) =>
            await _mediator.Send(request);

        /// <summary>
        /// Cria um Item dentro de uma Opção existente
        /// </summary>
        /// <param name="request"> Request com nome do Item</param>
        /// <param name="idOption">Id da Opção que receberá um Item</param>
        /// <returns>Retorna o Id e Nome do Item criado</returns>
        [HttpPost("api/Options/{idOption}/Items"), AllowAnonymous]
        public async Task<CreateItemResponse> Post(CreateItemOptionRequest request, Guid idOption)
        {
            var command = new CreateItemOptionRequest(request, idOption);
            var response = await _mediator.Send(command);
            return response;
        }

        /// <summary>
        /// Obtem todos os Itens associados com uma Opção
        /// </summary>
        /// <param name="idOption">Id da opção que deseja obter os itens</param>
        /// <returns>Retorna todos os Itens associados a uma Opção</returns>
        [HttpGet("api/Items/{idOption}"), AllowAnonymous]
        public async Task<GetItemsByOptionIdResponse> GetByOptionId(Guid idOption) =>
            await _mediator.Send( new GetItemsByOptionIdRequest(idOption));

        /// <summary>
        /// Deleta um ou mais Itens a partir de seus Ids
        /// </summary>
        /// <param name="request">Request com um array de Ids dos Itens que serão deletados</param>
        /// <returns>Retorna a quantidade de Itens que foram deletados</returns>
        [HttpDelete("api/Items"), AllowAnonymous]
        public async Task<DeleteMultiplesItemsResponse> DeleteMultiples(
                DeleteMultiplesItemsRequest request
            ) => await _mediator.Send(request);

        /// <summary>
        /// Remove a associação com uma Tabela de preço
        /// </summary>
        /// <param name="idItem">idItem que perderá a referencia com uma tabela de preço</param>
        /// <returns>Retorna o Id do item</returns>
        [HttpDelete("api/items/{idItem:Guid}"), AllowAnonymous]
        public async Task<RemovePriceRangeResponse> Remove(Guid idItem) =>
            await _mediator.Send(new RemovePriceRangeRequest(idItem));

        /// <summary>
        /// Adiciona uma Tabela de Preço(PriceRange) ao item, mesmo que ele já tenha sido associado com
        /// outra Tabela de Preço
        /// </summary>
        /// <param name="request">Request com o Id do Item e o Id da Tabela de Preço 
        /// que o item será associado</param>
        /// <returns>Retorna os Nomes e Ids do Item e da Tabela de Preço</returns>
        [HttpPut("api/Items"), AllowAnonymous]
        public async Task<PutItemResponse> Put(PutItemRequest request) =>
            await _mediator.Send(request);
    }
}
