using Marketplace.App.Notifications;
using Marketplace.Domain.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Marketplace.App.Handlers.Items
{
    public class GetItemsByOptionIdHandler :
        IRequestHandler<GetItemsByOptionIdRequest, GetItemsByOptionIdResponse>
    {
        private readonly IItemRepository _itemRepository;
        private readonly NotificationContext _notificationContext;

        public GetItemsByOptionIdHandler(
            IItemRepository itemRepository, NotificationContext notificationContext)
        {
            _itemRepository = itemRepository;
            _notificationContext = notificationContext;
        }

        public async Task<GetItemsByOptionIdResponse> Handle(
            GetItemsByOptionIdRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                _notificationContext.AddNotification("Request", "Request idOption não pode ser vazio");
                return null;
            }

            var items = await _itemRepository.GetByOptionIdAsync(request.IdOption);

            return new GetItemsByOptionIdResponse(items);
        }
    }
}
