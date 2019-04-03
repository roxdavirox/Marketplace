using System.Threading;
using System.Threading.Tasks;
using Marketplace.App.Notifications;
using Marketplace.Domain.Interfaces.Repositories;
using MediatR;

namespace Marketplace.App.Handlers.Items {
  public class DeleteMultiplesItemsHandler : IRequestHandler<DeleteMultiplesItemsRequest, DeleteMultiplesItemsResponse>
  {
    private readonly NotificationContext _notificationContext;
    private readonly IItemRepository _itemRepository;

    public DeleteMultiplesItemsHandler(NotificationContext notificationContext, IItemRepository itemRepository)
    {
      _notificationContext = notificationContext;
      _itemRepository = itemRepository;
    }

    public async Task<DeleteMultiplesItemsResponse> Handle(DeleteMultiplesItemsRequest request, CancellationToken cancellationToken)
    {
      if (request == null) {
        _notificationContext.AddNotification("Request null", "os ids não podem ser vazios");
        return null;
      }

      var itemsIds = request.ItemsIds;

      var items = await _itemRepository.GetByIdsAsync(itemsIds);

      if( items == null) {
        _notificationContext.AddNotification("Items", "Nenhum item encontrado");
        return null;
      }

      var deletedItemsCount = await _itemRepository.RemoveRange(items);

      if(deletedItemsCount == 0) {
        _notificationContext.AddNotification("Items count", "Nenhum item deletado");
        return null;
      }

      return new DeleteMultiplesItemsResponse(deletedItemsCount);
    }
  }
}