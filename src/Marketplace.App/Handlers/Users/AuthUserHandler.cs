using Marketplace.Shared.Extensions;
using Marketplace.App.Notifications;
using Marketplace.App.Services.Jwt;
using Marketplace.Domain.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Marketplace.App.Handlers.Users
{
    public class AuthUserHandler : IRequestHandler<AuthUserRequest, AuthUserResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;
        private readonly NotificationContext _notificationContext;

        public AuthUserHandler(
            IUserRepository userRepository,
            IJwtService jwtService,
            NotificationContext notificationContext)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
            _notificationContext = notificationContext;
        }

        public async Task<AuthUserResponse> Handle(AuthUserRequest request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Email))
            {
                _notificationContext.AddNotification("Email", "Email não pode ser vazio");
                return null;
            }

            if (string.IsNullOrEmpty(request.Password))
            {
                _notificationContext.AddNotification("Password", "Senha não pode ser vazia");
                return null;
            }

            var passwordMd5 = request.Password.ToMd5();

            var user = await _userRepository.AuthenticateAsync(request.Email, passwordMd5);

            if(user == null)
            {
                _notificationContext.AddNotification("User", "Usuário não encontrado");
                return null;
            }

            return (AuthUserResponse) user;
        }
    }
}
