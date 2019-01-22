using Marketplace.App.Notifications;
using Marketplace.Domain.Entities;
using Marketplace.Domain.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Marketplace.App.Services.Handlers.Options
{
    public class CreateOptionHandler : IRequestHandler<CreateOptionRequest, CreateOptionResponse>
    {
        private readonly IOptionRepository _optionRepository;
        private readonly NotificationContext _notificationContext;

        public CreateOptionHandler(
            IOptionRepository optionRepository, NotificationContext notificationContext)
        {
            _optionRepository = optionRepository;
            _notificationContext = notificationContext;
        }

        public async Task<CreateOptionResponse> Handle(
            CreateOptionRequest request, CancellationToken cancellationToken)
        {
            var option = new Option(request.Name);

            if(option.Invalid)
            {
                _notificationContext.AddNotifications(option.ValidationResult);
                return null;
            }

            await _optionRepository.CreateAsync(option);

            return (CreateOptionResponse)option;
        }
    }
}
