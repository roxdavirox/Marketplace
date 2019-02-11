using Marketplace.App.Notifications;
using Marketplace.Domain.Entities;
using Marketplace.Domain.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Marketplace.App.Handlers.Options
{
    public class CreateOptionItemHandler : IRequestHandler<CreateOptionItemRequest, CreateOptionItemResponse>
    {
        private readonly NotificationContext _notificationContext;
        private readonly IItemRepository _itemRepository;
        private readonly IOptionRepository _optionRepository;

        public CreateOptionItemHandler(
            NotificationContext notificationContext, 
            IItemRepository itemRepository, 
            IOptionRepository optionRepository)
        {
            _notificationContext = notificationContext;
            _itemRepository = itemRepository;
            _optionRepository = optionRepository;
        }

        public async Task<CreateOptionItemResponse> Handle(
            CreateOptionItemRequest request, CancellationToken cancellationToken)
        {
            var item = await _itemRepository.GetByIdAsync(request.IdItem);

            if(item == null)
            {
                _notificationContext.AddNotification("Item null", "Item não encontrado");
                return null;
            }

            var option = new Option(request.Name);

            if (option.Invalid)
            {
                _notificationContext.AddNotifications(option.ValidationResult);
                return null;
            }

            item.AssociateWith(option);

            await _optionRepository.CreateAsync(option);

            return new CreateOptionItemResponse(item, option);
        }
    }
}
