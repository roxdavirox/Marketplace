using Marketplace.App.Handlers.Users;
using Marketplace.App.Services.Jwt;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Marketplace.Api.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IJwtService _jwtService;

        public UserController(IMediator mediator, IJwtService jwtService)
        {
            _mediator = mediator;
            _jwtService = jwtService;
        }

        /// <summary>
        /// Cria um novo Usuario no sistema
        /// </summary>
        /// <param name="request">Request com Nome,Email e Senha</param>
        /// <returns>Retorna o Nome e Id do Usuario criado</returns>
        [HttpPost("api/users/register"), Authorize(Roles = "Adm"), AllowAnonymous]
        public async Task<CreateUserResponse> Post(CreateUserRequest request) =>
            await _mediator.Send(request);

        /// <summary>
        /// Autentica um Usuario no sistema
        /// </summary>
        /// <param name="request">Request com Email e Senha do Usuario</param>
        /// <returns>Retorna um JWT com os dados do usuario caso for autenticado, 
        /// caso contrario retorna mensagens de erro</returns>
        [HttpPost("api/users/login"), AllowAnonymous]
        public async Task<object> Post(AuthUserRequest request)
        {
            var authResponse = await _mediator.Send(request);

            var authFail = authResponse is null;

            if (authFail) return null;

            return _jwtService.CreateJwt(authResponse);
        }

    }
}
