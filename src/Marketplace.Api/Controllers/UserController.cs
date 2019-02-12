using Marketplace.App.Handlers.Users;
using Marketplace.App.Notifications;
using Marketplace.App.Services.Jwt;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Marketplace.Api.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IJwtService _jwtService;
        private readonly NotificationContext _notifications;

        public UserController(
            IMediator mediator, 
            IJwtService jwtService, 
            NotificationContext notifications)
        {
            _mediator = mediator;
            _jwtService = jwtService;
            _notifications = notifications;
        }

        [HttpPost("api/users/register")]
        public async Task<CreateUserResponse> Post(CreateUserRequest request) =>
            await _mediator.Send(request);

        [HttpPost("api/users/login")]
        public async Task<object> Post(AuthUserRequest request)
        {
            var authResponse = await _mediator.Send(request);

            var authFail = authResponse is null;

            if (authFail) return null;

            return _jwtService.CreateJwt(authResponse);
        }

    }
}
