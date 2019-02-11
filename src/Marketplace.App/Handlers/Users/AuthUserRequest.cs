using MediatR;

namespace Marketplace.App.Handlers.Users
{
    public class AuthUserRequest : IRequest<object>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
