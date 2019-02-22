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
            IEnumerable<CreateFullProductRequest_Option> ops) {
                var options = ops.Select(SelectProductOption)
                    .Select(o => o.Result)
                    .ToList();

                return options;
            }


        private IEnumerable<Item> SelectOptionItems(
            IEnumerable<CreateFullProductRequest_Item> items) {
                var _items = items.Select(SelectOptionItem)
                    .Select(i => i.Result)
                    .ToList();

                return _items;
        }

        private async Task<Option> SelectProductOption(
            CreateFullProductRequest.CreateFullProductRequest_Option o
            )
        {
            var items = SelectOptionItems(o.Items);

            var invalidItems = items.Any(i => i.Invalid);

            if (invalidItems)
            {
                _notificationContext.AddNotification("Item", "invalid item");
                return null;
            }

            await _itemRepository.CreateRangeAsync(items);

            var option = new Option(o.Name).AddItems(items);

            return option;
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
            CreateFullProductRequest_Price p, PriceRange pr) {
                var price = new Price(p.Start, p.End, p.Value)
                    .AssociateWith(pr);

                return price;
        }

        private IEnumerable<Price> SelectItemPrices(
            IEnumerable<CreateFullProductRequest_Price> prices,
            PriceRange pr) {
                var _prices = prices.Select(p => SelectItemPrice(p, pr));

                return _prices;
            }

        private async Task<Item> SelectOptionItem(
            CreateFullProductRequest_Item i
            )
        {
            var priceRange = await GetPriceRangeAsync();

            var prices = SelectItemPrices(i.Prices, priceRange);

            var invalidPrices = prices.Any(p => p.Invalid);
            
            if (invalidPrices)
            {
                _notificationContext.AddNotification("Prices", "Invalid prices");
                return null;
            }

            await _priceRepository.CreateRangeAsync(prices);

            return new Item(i.Name, priceRange);
        }
    }

}