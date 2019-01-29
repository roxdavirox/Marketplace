using Marketplace.App.Notifications;
using Marketplace.Domain.Entities;
using Marketplace.Domain.Interfaces.Repositories;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Marketplace.App.Services.Handlers.Items
{
    public class CreateItemHandler : IRequestHandler<CreateItemRequest, CreateItemResponse>
    {
        private readonly IItemRepository _itemRepository;
        private readonly IPriceRepository _priceRepository;
        private readonly NotificationContext _notificationContext;

        public CreateItemHandler(
            IItemRepository itemRepository, 
            IPriceRepository priceRepository, 
            NotificationContext notificationContext)
        {
            _itemRepository = itemRepository;
            _priceRepository = priceRepository;
            _notificationContext = notificationContext;
        }

        public async Task<CreateItemResponse> Handle(
            CreateItemRequest request, CancellationToken cancellationToken)
        {
            
            var item = new Item(request.Name);

            var prices = request.Prices.Select(p => new Price(item, p.Start, p.End, p.Value)); ;

            if (item.Invalid)
            {
                _notificationContext.AddNotifications(item.ValidationResult);
                return null;
            }

            await _priceRepository.CreateAsync(prices);

            await _itemRepository.CreateAsync(item);

            return (CreateItemResponse)item;
        }
    }

}
