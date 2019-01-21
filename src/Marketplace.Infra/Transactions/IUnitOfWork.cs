using System.Threading.Tasks;

namespace Marketplace.Infra.Transactions
{
    public interface IUnitOfWork
    {
        void Commit();
        Task<int> CommitAsync();
    }
}
