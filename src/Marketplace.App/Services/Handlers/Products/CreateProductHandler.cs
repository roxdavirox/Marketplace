using Marketplace.App.Notifications;
using Marketplace.Domain.Entities;
using Marketplace.Domain.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Marketplace.App.Services.Handlers.Products
{
    public class CreateProductHandler : IRequestHandler<CreateProductRequest, CreateProductResponse>
    {
        private readonly IProductRepository _repository;
        private readonly NotificationContext _notificationContext;

        public CreateProductHandler(
            IProductRepository repository,
            NotificationContext notificationContext
            )
        {
            _repository = repository;
            _notificationContext = notificationContext;
        }

        public async Task<CreateProductResponse> Handle(
            CreateProductRequest request, CancellationToken cancellationToken)
        {
            var product = new Product(request.Name);

            if (product.Invalid)
            {
                _notificationContext.AddNotifications(product.ValidationResult);
                return null;
            }

            await _repository.CreateAsync(product);

            return (CreateProductResponse)product;
        }
    }
}
