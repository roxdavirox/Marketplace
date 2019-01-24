using Marketplace.App.Notifications;
using Marketplace.Domain.Entities;
using Marketplace.Domain.Interfaces.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Marketplace.App.Services.Handlers.Items
{
    public class CreateItemHandler : IRequestHandler<CreateItemRequest, CreateItemResponse>
    {
        private readonly IItemRepository _itemRepository;
        private readonly NotificationContext _notificationContext;

        public CreateItemHandler(IItemRepository itemRepository, NotificationContext notificationContext)
        {
            _itemRepository = itemRepository;
            _notificationContext = notificationContext;
        }

        public async Task<CreateItemResponse> Handle(
            CreateItemRequest request, CancellationToken cancellationToken)
        {
            var price = request.GetPrice();

            var item = new Item(request.Name);

            if(item.Invalid)
            {
                _notificationContext.AddNotifications(item.ValidationResult);
                return null;
            }

            await _itemRepository.CreateAsync(item);

            return (CreateItemResponse)item;
        }
    }

    internal static class CreateItemRequestExtension
    {
        public static Price GetPrice(this CreateItemRequest request) =>
            request.Fixed 
                ? CreateFixedPrice(request) 
                : CreateRelativePrice(request);

        private static Price CreateFixedPrice(CreateItemRequest request) =>
            new Price(request.Fixed, request.FixedPrice.Value);

        private static IEnumerable<PriceInterval> GetPriceIntervals(this CreateItemRequest request) =>
            request.RelativePrice.Table
                .Select(i => new PriceInterval(i.Start, i.End, i.Value));

        private static RelativePrice GetRelativePrice(this CreateItemRequest request) =>
            new RelativePrice(request.GetPriceIntervals());

        private static Price CreateRelativePrice(CreateItemRequest request) =>
            new Price(request.GetRelativePrice());
    }
}
