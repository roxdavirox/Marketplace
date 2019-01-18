using Microsoft.Extensions.DependencyInjection;

namespace Marketplace.Infra.IoC.Containers.Interfaces
{
    public interface IServiceContainer
    {
        void AddServices(IServiceCollection services);
    }
}
