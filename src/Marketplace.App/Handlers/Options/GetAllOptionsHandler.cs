using Marketplace.App.Notifications;
using Marketplace.Domain.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Marketplace.App.Handlers.Options
{
    public class GetAllOptionsHandler : IRequestHandler<GetAllOptionsRequest, GetAllOptionsResponse>
    {
        private readonly NotificationContext _notificationContext;
        private readonly IOptionRepository _optionRepository;

        public GetAllOptionsHandler(
            NotificationContext notificationContext, IOptionRepository optionRepository)
        {
            _notificationContext = notificationContext;
            _optionRepository = optionRepository;
        }

        public async Task<GetAllOptionsResponse> Handle(
            GetAllOptionsRequest request, CancellationToken cancellationToken)
        {
            if(request == null)
            {
                _notificationContext.AddNotification("Request GetAllOptions", "Request vazio - nulo");
                return null;
            }

            var options = await _optionRepository.GetAllAsync();

            return new GetAllOptionsResponse(options);
        }
    }
}
