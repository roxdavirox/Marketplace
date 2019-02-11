using Marketplace.App.Extensions;
using Marketplace.App.Notifications;
using Marketplace.Domain.Entities;
using Marketplace.Domain.Interfaces.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Marketplace.App.Services.Handlers.Users
{
    public class CreateUserHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly NotificationContext _notificationContext;

        public CreateUserHandler(
            IUserRepository userRepository,
            NotificationContext notificationContext
            )
        {
            _userRepository = userRepository;
            _notificationContext = notificationContext;
        }

        public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var passwordMd5 = request.Password.ToMd5();
            var user = new User(request.Name, request.Email, passwordMd5);

            if (user.Invalid)
            {
                _notificationContext.AddNotifications(user.ValidationResult);
                return null;
            }

            await _userRepository.CreateAsync(user);

            return (CreateUserResponse)user;
        }
    }
}
