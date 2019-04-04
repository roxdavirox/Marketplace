using Marketplace.App.Notifications;
using Marketplace.Domain.Entities;
using Marketplace.Domain.Interfaces.Repositories;
using Marketplace.Shared.Extensions;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Marketplace.App.Handlers.PricesRange
{
    public class CreatePriceRangeHandler :
        IRequestHandler<CreatePriceRangeRequest, CreatePriceRangeResponse>
    {
        private readonly NotificationContext _notificationContext;
        private readonly IPriceRepository _priceRepository;
        private readonly IPriceRangeRepository _priceRangeRepository;

        public CreatePriceRangeHandler
            (NotificationContext notificationContext,
            IPriceRepository priceRepository,
            IPriceRangeRepository priceRangeRepository)
        {
            _notificationContext = notificationContext;
            _priceRepository = priceRepository;
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

            var prices = request.Prices
                .Select(p => new Price(p.Start, p.End, p.Value))
                .ToList();

            var invalidPrice = prices.Any(p => p.Invalid);

            if (invalidPrice)
            {
                prices.Where(_ => _.Invalid)
                    .ForEach(p => _notificationContext.AddNotifications(p.ValidationResult));
                return null;
            }

            var priceRange = new PriceRange(request.Name);
            priceRange.HasMany(prices);

            if (priceRange.Invalid)
            {
                _notificationContext.AddNotifications(priceRange.ValidationResult);
                return null;
            }

            await _priceRepository.CreateRangeAsync(prices);

            await _priceRangeRepository.CreateAsync(priceRange);

            return (CreatePriceRangeResponse)priceRange;
        }
    }
}
