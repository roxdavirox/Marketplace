﻿using Marketplace.App.Notifications;
using Marketplace.Domain.Entities;
using Marketplace.Domain.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Marketplace.App.Handlers.Items
{
    public class CreateItemHandler : IRequestHandler<CreateItemRequest, CreateItemResponse>
    {
        private readonly IItemRepository _itemRepository;
        private readonly NotificationContext _notificationContext;

        public CreateItemHandler(
            IItemRepository itemRepository,
            NotificationContext notificationContext)
        {
            _itemRepository = itemRepository;
            _notificationContext = notificationContext;
        }

        public async Task<CreateItemResponse> Handle(
            CreateItemRequest request, CancellationToken cancellationToken)
        {       
            var item = new Item(request.Name);

            if (item.Invalid)
            {
                _notificationContext.AddNotifications(item.ValidationResult);
                return null;
            }

            await _itemRepository.CreateAsync(item);
            
            return (CreateItemResponse)item;
        }
    }

}
