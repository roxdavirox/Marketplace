using Marketplace.App.Notifications;
using Marketplace.Domain.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Marketplace.App.Handlers.Items
{
    public class PutItemHandler : IRequestHandler<PutItemRequest, PutItemResponse>
    {
        private readonly NotificationContext _notificationContext;
        private readonly IItemRepository _itemRepository;
        private readonly IPriceRangeRepository _priceRangeRepository;

        public PutItemHandler(
            NotificationContext notificationContext, 
            IItemRepository itemRepository, 
            IPriceRangeRepository priceRangeRepository)
        {
            _notificationContext = notificationContext;
            _itemRepository = itemRepository;
            _priceRangeRepository = priceRangeRepository;
        }

        public async Task<PutItemResponse> Handle(
            PutItemRequest request, CancellationToken cancellationToken)
        {
            if( request == null)
            {
                _notificationContext.AddNotification("Request", "Request não pode ser nulo");
                return null;
            }

            var priceRange = await _priceRangeRepository.GetByIdAsync(request.IdPriceRange);

            if(priceRange == null)
            {
                _notificationContext.AddNotification("PriceRange", "price range não encontrado");
                return null;
            }

            var item = await _itemRepository.GetByIdAsync(request.IdItem);

            if(item == null)
            {
                _notificationContext.AddNotification("Item", "Item não encontrado");
                return null;
            }

            item.HasOne(priceRange);

            return new PutItemResponse(priceRange, item);
        }
    }
}
