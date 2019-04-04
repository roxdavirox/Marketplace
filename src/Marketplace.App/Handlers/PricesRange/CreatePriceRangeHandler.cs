using Marketplace.App.Notifications;
using Marketplace.Domain.Entities;
using Marketplace.Domain.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Marketplace.App.Handlers.PricesRange
{
    public class CreatePriceRangeHandler :
        IRequestHandler<CreatePriceRangeRequest, CreatePriceRangeResponse>
    {
        private readonly NotificationContext _notificationContext;
        private readonly IPriceRangeRepository _priceRangeRepository;

        public CreatePriceRangeHandler
            (NotificationContext notificationContext,
            IPriceRangeRepository priceRangeRepository)
        {
            _notificationContext = notificationContext;
            _priceRangeRepository = priceRangeRepository;
        }

        public async Task<CreatePriceRangeResponse> Handle(
            CreatePriceRangeRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                _notificationContext.AddNotification("Request", "request nulo");
                return null;
            }

            var priceRange = new PriceRange(request.Name);

            if (priceRange.Invalid)
            {
                _notificationContext.AddNotifications(priceRange.ValidationResult);
                return null;
            }

            await _priceRangeRepository.CreateAsync(priceRange);

            return (CreatePriceRangeResponse)priceRange;
        }
    }
}
