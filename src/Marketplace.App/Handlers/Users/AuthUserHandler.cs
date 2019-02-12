using Marketplace.App.Notifications;
using Marketplace.Domain.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Marketplace.App.Handlers.Users
{
    public class AuthUserHandler : IRequestHandler<AuthUserRequest, object>
    {
        private readonly IUserRepository _userRepository;
        //private readonly IJwtService _jwtService;
        private readonly NotificationContext _notificationContext;

        public AuthUserHandler(
            IUserRepository userRepository, NotificationContext context)
        {
            _userRepository = userRepository;
            _notificationContext = context;
        }

        public async Task<object> Handle(AuthUserRequest request, CancellationToken cancellationToken)
        {
            if(string.IsNullOrEmpty(request.Email))
            {
                _notificationContext.AddNotification("Email", "Email não pode ser vazio");
                return null;
            }

            if(string.IsNullOrEmpty(request.Password))
            {
                _notificationContext.AddNotification("Password", "Senha não pode ser vazia");
                return null;
            }

           var user = await _userRepository.AuthenticateAsync(request.Email, request.Password);

            // implementar criação do jwt aqui
            return user;
        }
    }
}
