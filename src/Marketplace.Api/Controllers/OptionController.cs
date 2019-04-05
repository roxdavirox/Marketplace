using Marketplace.App.Handlers.Options;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Marketplace.Api.Controllers
{
    [ApiController, Authorize(Roles = "Adm")]
    public class OptionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OptionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Cria uma Opção associando com um Produto existente
        /// </summary>
        /// <param name="request">Request com o nome da Opção quer será criada</param>
        /// <param name="idProduct">Id do produto que será associado com a nova Opção</param>
        /// <returns>Retorna o Nome e Id da Opção criada</returns>
        [HttpPost("api/Products/{idProduct:Guid}/Options"), AllowAnonymous]
        public async Task<CreateOptionResponse> Post(CreateOptionProductRequest request, Guid idProduct)
        {
            var command = new CreateOptionProductRequest(request, idProduct);
            return await _mediator.Send(command);
        }

        /// <summary>
        /// Cria uma nova Opção no sistema
        /// </summary>
        /// <param name="request">Request com o nome da nova Opção</param>
        /// <returns>Retorna o Id e Nome da Opção criada</returns>
        [HttpPost("api/Options"), AllowAnonymous]
        public async Task<CreateOptionResponse> Post(CreateOptionRequest request) =>
            await _mediator.Send(request);

        /// <summary>
        /// Associa um Item existente a uma Opção existente
        /// </summary>
        /// <param name="request">Request com os Ids do Item e da Opção</param>
        /// <returns>Retorna os Ids e Nomes da Opção e do Item associados</returns>
        [HttpPut("api/Options/Items"), AllowAnonymous]
        public async Task<PutOptionItemResponse> Put(PutOptionItemRequest request) =>
            await _mediator.Send(request);

        /// <summary>
        /// Cria uma nova Opção e associa com um Item existente no sistema
        /// </summary>
        /// <param name="request">Request com o nome da Opção que será criada</param>
        /// <param name="idItem">Id do Item que a nova Opção será associada</param>
        /// <returns>Retorna os Ids e Nomes da Opção e do Item associados</returns>
        [HttpPost("api/Items/{idItem:Guid}/Options"), AllowAnonymous]
        public async Task<CreateOptionItemResponse> Post(CreateOptionItemRequest request, Guid idItem)
        {
            var command = new CreateOptionItemRequest(request, idItem);

            var response = await _mediator.Send(command);

            return response;
        }

        /// <summary>
        /// Obtem todas as Opções existentes no sistema
        /// </summary>
        /// <returns>Retorna uma lista com Id e Nome de cada Opção</returns>
        [HttpGet("api/Options"), AllowAnonymous]
        public async Task<GetAllOptionsResponse> GetAll() =>
            await _mediator.Send(new GetAllOptionsRequest());

        /// <summary>
        /// Deleta uma ou mais Opções a partir de seus Ids
        /// </summary>
        /// <param name="request">Request com uma lista de Ids de Opções que serão deletadas</param>
        /// <returns>Retorna a quantidade de Opções deletadas</returns>
        [HttpDelete("api/Options"), AllowAnonymous]
        public async Task<DeleteOptionsResponse> DeleteMultiples(
                DeleteOptionsRequest request
            ) => await _mediator.Send(request);
    }
}
