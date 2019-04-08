using System.Threading;
using System.Threading.Tasks;
using Marketplace.App.Notifications;
using Marketplace.Domain.Interfaces.Repositories;
using MediatR;

namespace Marketplace.App.Handlers.Prices {
  public class DeletePricesHandler
    : IRequestHandler<DeletePricesRequest, DeletePricesResponse>
  {
    private readonly NotificationContext _notificationContext;
    private readonly IPriceRepository _priceRepository;

    public DeletePricesHandler(
      NotificationContext notificationContext, IPriceRepository priceRepository)
    {
      _notificationContext = notificationContext;
      _priceRepository = priceRepository;
    }

    public async Task<DeletePricesResponse> Handle(DeletePricesRequest request, CancellationToken cancellationToken)
    {
      if (request == null) {
        _notificationContext.AddNotification("Request", "request não pode ser nulo");
        return null;
      }

      var pricesIds = request.PricesIds;

      var prices = await _priceRepository.GetByIdsAsync(pricesIds);

      if (prices == null) {
        _notificationContext
          .AddNotification("Prices", "Nenhum price encontrado");
        return null;
      }

      var deletedCount = await _priceRepository.RemoveRangeAsync(prices);

      if (deletedCount == 0) {
        _notificationContext.AddNotification("DeletecCount", "Nenhum price deletado");
        return null;
      }

      return new DeletePricesResponse(deletedCount);
    }
  }
}