using Marketplace.App.Notifications;
using Marketplace.Domain.Entities;
using Marketplace.Domain.Interfaces.Repositories;
using MediatR;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static Marketplace.App.Handlers.Products.CreateFullProductRequest;
using static Marketplace.App.Handlers.Products.CreateFullProductRequest.CreateFullProductRequest_Option;
using static Marketplace.App.Handlers.Products.CreateFullProductRequest.CreateFullProductRequest_Option.CreateFullProductRequest_Item;

namespace Marketplace.App.Handlers.Products
{
    public class CreateFullProductHandler : 
        IRequestHandler<CreateFullProductRequest, CreateFullProductResponse>
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

            var options = SelectProductOptions(request.Options);

            var invalidOptions = options.Any(o => o.Invalid);

            if (invalidOptions)
            {
                _notificationContext.AddNotification("Options", "Invalid options");
                return null;
            }

            options.ForEach(o => o.AssociateWith(product));

            await _optionRepository.CreateRangeAsync(options);

            return (CreateFullProductResponse) product;
        }

        private IEnumerable<Option> SelectProductOptions(
            IEnumerable<CreateFullProductRequest_Option> options) =>
                options.Select(SelectProductOption)
                    .Select(o => o.Result)
                    .ToList();

        private IEnumerable<Item> SelectOptionItems(
            IEnumerable<CreateFullProductRequest_Item> items) =>
                items.Select(SelectOptionItem)
                    .Select(item => item.Result)
                    .ToList();

        private async Task<Option> SelectProductOption(
            CreateFullProductRequest_Option option
            )
        {
            var items = SelectOptionItems(option.Items);

            var invalidItems = items.Any(item => item.Invalid);

            if (invalidItems)
            {
                _notificationContext.AddNotification("Item", "invalid item");
                return null;
            }

            await _itemRepository.CreateRangeAsync(items);

            return new Option(option.Name).AddItems(items);
        }

        private async Task<PriceRange> GetPriceRangeAsync() {
            var priceRange = new PriceRange();

            if (priceRange.Invalid)
            {
                _notificationContext.AddNotifications(priceRange.ValidationResult);
                return null;
            }

            await _priceRangeRepository.CreateAsync(priceRange);

            return priceRange;
        }

        private Price SelectItemPrice(
            CreateFullProductRequest_Price price, PriceRange priceRange) =>
                new Price(price.Start, price.End, price.Value)
                    .AssociateWith(priceRange);

        private IEnumerable<Price> SelectItemPrices(
            IEnumerable<CreateFullProductRequest_Price> prices, PriceRange priceRange) => 
                prices.Select(p => SelectItemPrice(p, priceRange));
        private async Task<Item> SelectOptionItem(
            CreateFullProductRequest_Item item
            )
        {
            var priceRange = await GetPriceRangeAsync();

            var prices = SelectItemPrices(item.Prices, priceRange);

            var invalidPrices = prices.Any(p => p.Invalid);
            
            if (invalidPrices)
            {
                _notificationContext.AddNotification("Prices", "Invalid prices");
                return null;
            }

            await _priceRepository.CreateRangeAsync(prices);

            return new Item(item.Name, priceRange);
        }
    }

}