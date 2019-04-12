using System.Threading;
using System.Threading.Tasks;
using Marketplace.App.Notifications;
using Marketplace.Domain.Interfaces.Repositories;
using MediatR;

namespace Marketplace.App.Handlers.Items {
  public class RemovePriceRangeHadler : IRequestHandler<RemovePriceRangeRequest, RemovePriceRangeResponse> {

    private readonly NotificationContext _notificationContext;
    private readonly IItemRepository _itemRepository;

    public RemovePriceRangeHadler(
      NotificationContext notificationContext, IItemRepository itemRepository)
    {
      _notificationContext = notificationContext;
      _itemRepository = itemRepository;
    }

    public async Task<RemovePriceRangeResponse> Handle(
      RemovePriceRangeRequest request, CancellationToken cancellationToken)
    {
      if (request == null) {
        _notificationContext.AddNotification("Request", "request nulo");
        return null;
      }

      var item = await _itemRepository.GetByIdAsync(request.IdItem);

      if(item == null) {
        _notificationContext.AddNotification("Item","Não encontrado");
        return null;
      }

      item.RemovePriceRange();

      return new RemovePriceRangeResponse(item);
    }
  }
}