using Marketplace.App.Notifications;
using Marketplace.Domain.Entities;
using Marketplace.Domain.Interfaces.Repositories;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Marketplace.App.Handlers.Items
{
    public class CreateItemHandler : IRequestHandler<CreateItemRequest, CreateItemResponse>
    {
        private readonly IItemRepository _itemRepository;
        private readonly IPriceRepository _priceRepository;
        private readonly IPriceRangeRepository _priceRangeRepository;
        private readonly NotificationContext _notificationContext;

        public CreateItemHandler(
            IItemRepository itemRepository, 
            IPriceRepository priceRepository, 
            IPriceRangeRepository priceRangeRepository, 
            NotificationContext notificationContext)
        {
            _itemRepository = itemRepository;
            _priceRepository = priceRepository;
            _priceRangeRepository = priceRangeRepository;
            _notificationContext = notificationContext;
        }

        public async Task<CreateItemResponse> Handle(
            CreateItemRequest request, CancellationToken cancellationToken)
        {
            var priceRange = new PriceRange();

            if (priceRange.Invalid)
            {
                _notificationContext.AddNotifications(priceRange.ValidationResult);
                return null;
            }

            var item = new Item(request.Name);
            item.HasOne(priceRange);

            if (item.Invalid)
            {
                _notificationContext.AddNotifications(item.ValidationResult);
                return null;
            }

            var prices = request.Prices
                .Select(p => new Price(p.Start, p.End, p.Value))
                .ToList();

            prices.ForEach(p => p.HasOne(priceRange));

            var invalidPrices = prices.Where(p => p.Invalid);

            var invalidPrice = invalidPrices.Any();

            if(invalidPrice)
            {
                invalidPrices.ForEach(p => _notificationContext.AddNotifications(p.ValidationResult));
                return null;
            }

            await _priceRangeRepository.CreateAsync(priceRange);

            await _itemRepository.CreateAsync(item);

            await _priceRepository.CreateRangeAsync(prices);

            return (CreateItemResponse)item;
        }
    }

}
