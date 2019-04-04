using Marketplace.App.Notifications;
using Marketplace.Domain.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Marketplace.App.Handlers.PricesRange
{
    public class GetAllPricesRangesHandler
        : IRequestHandler<GetAllPricesRangeRequest, GetAllPricesRangeResponse>
    {
        private readonly NotificationContext _notificationContext;
        private readonly IPriceRangeRepository _priceRangeRepository;

        public GetAllPricesRangesHandler(
            NotificationContext notificationContext, IPriceRangeRepository priceRangeRepository)
        {
            _notificationContext = notificationContext;
            _priceRangeRepository = priceRangeRepository;
        }

        public async Task<GetAllPricesRangeResponse> Handle(
            GetAllPricesRangeRequest request, CancellationToken cancellationToken)
        {
            if(request == null)
            {
                _notificationContext.AddNotification("Request", "o request não pode ser nulo");
                return null;
            }

            var pricesRange = await _priceRangeRepository.GetAllAsync();

            return new GetAllPricesRangeResponse(pricesRange);
        }
    }
}
