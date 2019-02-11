using MediatR;

namespace Marketplace.App.Services.Handlers.Users
{
    public class CreateUserRequest : IRequest<CreateUserResponse>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
