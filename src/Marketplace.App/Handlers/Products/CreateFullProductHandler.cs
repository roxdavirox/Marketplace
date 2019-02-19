using Marketplace.App.Notifications;
using Marketplace.Domain.Entities;
using Marketplace.Domain.Interfaces.Repositories;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Marketplace.App.Handlers.Products
{
    public class CreateFullProductHandler : IRequestHandler<CreateFullProductRequest, CreateFullProductResponse>
    {
        private readonly NotificationContext _notificationContext;
        private readonly IProductRepository _productRepository;
        private readonly IOptionRepository _optionRepository;
        private readonly IPriceRepository _priceRepository;
        private readonly IPriceRangeRepository _priceRangeRepository;
        private readonly IItemRepository _itemRepository;

        public CreateFullProductHandler(
            NotificationContext notificationContext,
            IProductRepository productRepository,
            IOptionRepository optionRepository,
            IPriceRepository priceRepository,
            IPriceRangeRepository priceRangeRepository,
            IItemRepository itemRepository
            )
        {
            _notificationContext = notificationContext;
            _productRepository = productRepository;
            _optionRepository = optionRepository;
            _priceRepository = priceRepository;
            _priceRangeRepository = priceRangeRepository;
            _itemRepository = itemRepository;
        }

        public async Task<CreateFullProductResponse> Handle(
          CreateFullProductRequest request, CancellationToken cancellationToken)
        {
            var product = new Product(request.Name);

            if (product.Invalid)
            {
                _notificationContext.AddNotification("Product", "Invalid product");
                return null;
            }

            await _productRepository.CreateAsync(product);

            if (request.Options == null)
            {
                _notificationContext.AddNotification("RequestOptions", "Request options is required");
                return null;
            }

            var options = request
               .Options
               .Select(o => CreateOptionChilds(o).Result)
               .ToList();

            var invalidOptions = options.Any(o => o.Invalid);

            if (invalidOptions)
            {
                _notificationContext.AddNotification("Options", "Invalid options");
                return null;
            }

            options.ForEach(o => o.AssociateWith(product));

            await _optionRepository.CreateRangeAsync(options);

            return (CreateFullProductResponse)product;
        }

        private async Task<Option> CreateOptionChilds(
            CreateFullProductRequest.CreateFullProductRequest_Option o
            )
        {
            var priceRange = new PriceRange();

            if (priceRange.Invalid)
            {
                _notificationContext.AddNotifications(priceRange.ValidationResult);
                return null;
            }

            await _priceRangeRepository.CreateAsync(priceRange);

            var items = o.Items
                .Select(i => CreateItemChilds(i, priceRange).Result)
                .ToList();

            var invalidItems = items.Any(i => i.Invalid);

            if (invalidItems)
            {
                _notificationContext.AddNotification("Item", "invalid item");
                return null;
            }

            await _itemRepository.CreateRangeAsync(items);

            var option = new Option(o.Name).AddItems(items);

            if (option.Invalid)
            {
                _notificationContext.AddNotifications(option.ValidationResult);
                return null;
            }

            return option;
        }

        private async Task<Item> CreateItemChilds(
            CreateFullProductRequest.CreateFullProductRequest_Option.CreateFullProductRequest_Item i,
            PriceRange pr
            )
        {
            var prices = i.Prices
                .Select(
                    p => new Price(p.Start, p.End, p.Value).AssociateWith(pr)
                )
                .ToList();

            var invalidPrices = prices.Any(p => p.Invalid);
            
            if (invalidPrices)
            {
                _notificationContext.AddNotification("Prices", "Invalid prices");
                return null;
            }

            await _priceRepository.CreateRangeAsync(prices);

            var item = new Item(i.Name, pr);

            return item;
        }
    }
}