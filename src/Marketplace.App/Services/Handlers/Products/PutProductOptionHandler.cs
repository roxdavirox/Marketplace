using Marketplace.App.Notifications;
using Marketplace.Domain.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Marketplace.App.Services.Handlers.Products
{
    public class PutProductOptionHandler : IRequestHandler<PutProductOptionRequest, PutProductOptionResponse>
    {
        private readonly NotificationContext _notificationContext;
        private readonly IProductRepository _productRepository;
        private readonly IOptionRepository _optionRepository;

        public PutProductOptionHandler(
            NotificationContext notificationContext, 
            IProductRepository productRepository, 
            IOptionRepository optionRepository)
        {
            _notificationContext = notificationContext;
            _productRepository = productRepository;
            _optionRepository = optionRepository;
        }

        public async Task<PutProductOptionResponse> Handle(
            PutProductOptionRequest request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.IdProduct);

            if(product == null)
            {
                _notificationContext.AddNotification("Product null", "Produto não encontrado");
                return null;
            }

            var option = await _optionRepository.GetByIdAsync(request.IdOption);

            if(option == null)
            {
                _notificationContext.AddNotification("Option null", "Opção não encontrada");
                return null;
            }

            option.AssociateWith(product);

            return new PutProductOptionResponse(product, option);
        }
    }
}
