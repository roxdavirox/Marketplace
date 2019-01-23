using Marketplace.App.Notifications;
using Marketplace.Domain.Entities;
using Marketplace.Domain.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Marketplace.App.Services.Handlers.Items
{
    public class CreateItemOptionHandler : IRequestHandler<CreateItemOptionRequest, CreateItemResponse>
    {
        private readonly NotificationContext _notificationContext;
        private readonly IItemRepository _itemRepository;
        private readonly IOptionRepository _optionRepository;

        public CreateItemOptionHandler(
            NotificationContext notificationContext, 
            IItemRepository itemRepository, 
            IOptionRepository optionRepository)
        {
            _notificationContext = notificationContext;
            _itemRepository = itemRepository;
            _optionRepository = optionRepository;
        }

        public async Task<CreateItemResponse> Handle(
            CreateItemOptionRequest request, CancellationToken cancellationToken)
        {
            var option = await _optionRepository.GetByIdASync(request.IdOption);

            if(option == null)
            {
                _notificationContext.AddNotification("Option null", "Opção não encontrada");
                return null;
            }

            var item = new Item(request.Name, option);

            if(item.Invalid)
            {
                _notificationContext.AddNotifications(item.ValidationResult);
                return null;
            }

            await _itemRepository.CreateAsync(item);

            return (CreateItemResponse)item;
        }
    }
}
