using Marketplace.App.Notifications;
using Marketplace.Domain.Entities;
using Marketplace.Domain.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Marketplace.App.Services.Handlers.Options
{
    public class CreateProductOptionHandler : IRequestHandler<CreateProductOptionRequest, CreateOptionResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IOptionRepository _optionRepository;
        private readonly NotificationContext _notificationContext;
        
        public CreateProductOptionHandler(
            IProductRepository productRepository, 
            IOptionRepository optionRepository, 
            NotificationContext notificationContext)
        {
            _productRepository = productRepository;
            _optionRepository = optionRepository;
            _notificationContext = notificationContext;
        }

        public async Task<CreateOptionResponse> Handle(
            CreateProductOptionRequest request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.IdProduct);

            if(product == null)
            {
                _notificationContext.AddNotification("product null", "O produto não foi encontrado");
                return null;
            }

            var option = new Option(request.Name, product);

            if(option.Invalid)
            {
                _notificationContext.AddNotifications(option.ValidationResult);
                return null;
            }

            await _optionRepository.CreateAsync(option);

            return (CreateOptionResponse)option;
        }
    }
}
