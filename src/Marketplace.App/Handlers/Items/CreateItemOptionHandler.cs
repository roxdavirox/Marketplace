using Marketplace.App.Notifications;
using Marketplace.Domain.Entities;
using Marketplace.Domain.Interfaces.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Marketplace.App.Handlers.Items
{
    public class CreateItemOptionHandler : IRequestHandler<CreateItemOptionRequest, CreateItemResponse>
    {
        private readonly NotificationContext _notificationContext;
        private readonly IItemRepository _itemRepository;
        private readonly IPriceRangeRepository _priceRangeRepository;
        private readonly IPriceRepository _priceRepository;
        private readonly IOptionRepository _optionRepository;
        
        public CreateItemOptionHandler(
            NotificationContext notificationContext, 
            IItemRepository itemRepository, 
            IPriceRangeRepository priceRangeRepository, 
            IPriceRepository priceRepository, 
            IOptionRepository optionRepository)
        {
            _notificationContext = notificationContext;
            _itemRepository = itemRepository;
            _priceRangeRepository = priceRangeRepository;
            _priceRepository = priceRepository;
            _optionRepository = optionRepository;
        }

        public async Task<CreateItemResponse> Handle(
            CreateItemOptionRequest request, CancellationToken cancellationToken)
        {
            var option = await _optionRepository.GetByIdAsync(request.IdOption);

            if (option == null)
            {
                _notificationContext.AddNotification("Option null", "Opção não encontrada");
                return null;
            }

            var priceRange = new PriceRange();
            
            var item = new Item(request.Name, option);
            item.HasOne(priceRange);
            item.HasOne(option);

            if (item.Invalid)
            {
                _notificationContext.AddNotifications(item.ValidationResult);
                return null;
            }

            var emptyPrice = new Price(1, 1, 1);

            emptyPrice.HasOne(priceRange);

            if(emptyPrice.Invalid)
            {
                _notificationContext.AddNotifications(emptyPrice.ValidationResult);
                return null;
            }

            await _priceRangeRepository.CreateAsync(priceRange);

            await _itemRepository.CreateAsync(item);

            await _priceRepository.CreateRangeAsync(new List<Price> { emptyPrice });

            return (CreateItemResponse)item;
        }
    }
}
