using Marketplace.App.Notifications;
using Marketplace.Domain.Interfaces.Repositories;
using Marketplace.Shared.Extensions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Marketplace.App.Handlers.Options
{
    public class DeleteOptionsHandler : IRequestHandler<DeleteOptionsRequest, DeleteOptionsResponse>
    {
        private readonly IOptionRepository _optionRepository;
        private readonly NotificationContext _notificationConext;

        public DeleteOptionsHandler(
            IOptionRepository optionRepository, NotificationContext notificationConext)
        {
            _optionRepository = optionRepository;
            _notificationConext = notificationConext;
        }

        public async Task<DeleteOptionsResponse> Handle(
            DeleteOptionsRequest request, CancellationToken cancellationToken)
        {
            if(request == null)
            {
                _notificationConext.AddNotification("Request", "Request não pode ser vazio");
                return null;
            }
            var optionsIds = request.OptionsIds;

            var options = await _optionRepository.GetByIdsAsync(optionsIds);

            if(options == null)
            {
                _notificationConext.AddNotification("Options", "nenhuma opção encontrada");
                return null;
            }

            options.ForEach(o => o.RemoveItems());

            var deletedOptionsCount = await _optionRepository.RemoveRange(options);

            if(deletedOptionsCount == 0)
            {
                _notificationConext.AddNotification("Deleted count", "Nenhuma opção foi deletada");
                return null;
            }

            return new DeleteOptionsResponse(deletedOptionsCount);
        }
    }
}
