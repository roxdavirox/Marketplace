using Marketplace.App.Notifications;
using Marketplace.Domain.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Marketplace.App.Handlers.Prices
{
    public class GetPricesHandler : IRequestHandler<GetPricesRequest, GetPricesResponse>
    {
        private readonly NotificationContext _notificationContext;
        private readonly IPriceRepository _priceRepository;

        public GetPricesHandler(
            NotificationContext notificationContext, IPriceRepository priceRepository)
        {
            _notificationContext = notificationContext;
            _priceRepository = priceRepository;
        }

        public async Task<GetPricesResponse> Handle(
            GetPricesRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                _notificationContext.AddNotification("Request", "Request idPriceRange não pode ser vazio");
                return null;
            }

            var prices = await _priceRepository.GetPricesByPriceRangeIdAsync(request.IdPriceRange);

            return new GetPricesResponse(prices);
        }
    }
}
