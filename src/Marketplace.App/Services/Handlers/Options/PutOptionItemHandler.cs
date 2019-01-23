using Marketplace.App.Notifications;
using Marketplace.Domain.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Marketplace.App.Services.Handlers.Options
{
    public class PutOptionItemHandler : IRequestHandler<PutOptionItemRequest, PutOptionItemResponse>
    {
        private readonly NotificationContext _notificationContext;
        private readonly IOptionRepository _optionRepository;
        private readonly IItemRepository _itemRepository;

        public PutOptionItemHandler(
            NotificationContext notificationContext, 
            IOptionRepository optionRepository, 
            IItemRepository itemRepository)
        {
            _notificationContext = notificationContext;
            _optionRepository = optionRepository;
            _itemRepository = itemRepository;
        }

        public async Task<PutOptionItemResponse> Handle(PutOptionItemRequest request, CancellationToken cancellationToken)
        {
            var option = await _optionRepository.GetByIdAsync(request.IdOption);

            if(option == null)
            {
                _notificationContext.AddNotification("Option null", "Opção não encontrada");
                return null;
            }

            var item = await _itemRepository.GetByIdAsync(request.IdItem);

            if(item == null)
            {
                _notificationContext.AddNotification("Item null", "Item não encontrado");
                return null;
            }

            item.AssociateWith(option);

            return new PutOptionItemResponse(item, option);
        }
    }
}
