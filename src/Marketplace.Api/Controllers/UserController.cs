using Marketplace.App.Handlers.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Marketplace.Api.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("api/users/register")]
        public async Task<CreateUserResponse> Post(CreateUserRequest request) =>
            await _mediator.Send(request);

        [HttpPost("api/users/login")]
        public async Task<object> Post(AuthUserRequest request) =>
            await _mediator.Send(request);

    }
}
