using Marketplace.App.Notifications;
using Marketplace.Domain.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Marketplace.App.Handlers.PricesRange
{
    public class DeletePricesRangeHandler 
        : IRequestHandler<DeletePricesRangeRequest, DeletePricesRangeResponse>
    {
        private readonly NotificationContext _notificationContext;
        private readonly IPriceRangeRepository _priceRangeRepository;

        public DeletePricesRangeHandler(
            NotificationContext notificationContext, IPriceRangeRepository priceRangeRepository)
        {
            _notificationContext = notificationContext;
            _priceRangeRepository = priceRangeRepository;
        }

        public async Task<DeletePricesRangeResponse> Handle(
            DeletePricesRangeRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                _notificationContext.AddNotification("Request", "Request não pode ser nulo");
                return null;
            }

            var ids = request.PricesRangesIds;

            var pricesRange = await _priceRangeRepository.GetByIdsAsync(ids);

            if (pricesRange == null)
            {
                _notificationContext
                    .AddNotification("Tabela de preço", "Nenhuma tabela de preço encontrada");
                return null;
            }

            var deletedCount = await _priceRangeRepository.RemoveRangeAsync(pricesRange);

            if(deletedCount == 0)
            {
                _notificationContext.AddNotification("PricesRange", "nenhum price range deletado");
                return null;
            }

            return new DeletePricesRangeResponse(deletedCount);
        }
    }
}
