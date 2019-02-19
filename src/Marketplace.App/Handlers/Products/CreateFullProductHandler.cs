using Marketplace.App.Notifications;
using Marketplace.Domain.Entities;
using Marketplace.Domain.Interfaces.Repositories;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Marketplace.App.Handlers.Products {
  public class CreateFullProductHandler : IRequestHandler<CreateFullProductRequest, CreateFullProductResponse> {
    private readonly NotificationContext _notificationContext;
    private readonly IProductRepository _productRepository;
    private readonly IOptionRepository _optionRepository;

    private readonly IItemRepository _itemRepository;

    public CreateFullProductHandler(
        NotificationContext notificationContext, 
        IProductRepository productRepository, 
        IOptionRepository optionRepository, 
        IItemRepository itemRepository
      )
    {
      _notificationContext = notificationContext;
      _productRepository = productRepository;
      _optionRepository = optionRepository;
      _itemRepository = itemRepository;
    }

    public  Task<CreateFullProductResponse> Handle(
      CreateFullProductRequest request, CancellationToken cancellationToken) {
        var product = new Product(request.Name);

        if (product.Invalid) {
          _notificationContext.AddNotification("Product", "Invalid product");
          return null;
        }

        if (request.Options == null ) {
          _notificationContext.AddNotification("RequestOptions", "Request options is required");
          return null;
        }

        var options = request
          .Options
          .Select(o => 
            new Option(o.Name, product)
              .AddItems(
                o.Items
                  .Select(
                    i => { new Item(i.Name).AssociateWith(new PriceRange()); }
                  )
                  .ToList()
              )
          )
          .ToList();

        var invalidOptions = options.Any(o => o.Invalid);

        if(invalidOptions) {
          _notificationContext.AddNotification("Optinos", "Invalid options");
          return null;
        }

        request.Options.Select(o => o.)
      }
  }
}