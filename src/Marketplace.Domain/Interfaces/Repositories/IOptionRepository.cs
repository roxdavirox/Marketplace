using Marketplace.Domain.Entities;
using System.Threading.Tasks;

namespace Marketplace.Domain.Interfaces.Repositories
{
    public interface IOptionRepository
    {
        Task<Option> CreateAsync(Option option);
    }
}
