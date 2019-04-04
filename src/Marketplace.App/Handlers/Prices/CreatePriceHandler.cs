using Marketplace.App.Notifications;
using Marketplace.Domain.Entities;
using Marketplace.Domain.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Marketplace.App.Handlers.Prices
{
    public class CreatePriceHandler :
        IRequestHandler<CreatePriceRequest, CreatePriceResponse>
    {
        private readonly NotificationContext _notificationContext;
        private readonly IPriceRepository _priceRepository;
        private readonly IPriceRangeRepository _priceRangeRepository;

        public CreatePriceHandler(
            NotificationContext notificationContext, 
            IPriceRepository priceRepository, 
            IPriceRangeRepository priceRangeRepository)
        {
            _notificationContext = notificationContext;
            _priceRepository = priceRepository;
            _priceRangeRepository = priceRangeRepository;
        }

        public async Task<CreatePriceResponse> Handle(
            CreatePriceRequest request, CancellationToken cancellationToken)
        {
            if(request == null)
            {
                _notificationContext.AddNotification("Request null", "O request não pode ser nulo");
                return null;
            }

            var priceRange = await _priceRangeRepository.GetByIdAsync(request.IdPriceRange);

            if ( priceRange == null)
            {
                _notificationContext.AddNotification("Price range", "Price range não encontrado");
                return null;
            }

            var price = new Price(
                    request.Start,
                    request.End,
                    request.Value
                );

            if(price.Invalid)
            {
                _notificationContext.AddNotifications(price.ValidationResult);
                return null;
            }

            price.HasOne(priceRange);

            await _priceRepository.CreateAsync(price);

            return new CreatePriceResponse(price.Id, priceRange.Id);
        }
    }
}
