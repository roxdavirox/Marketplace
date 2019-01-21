using Marketplace.Infra.Data.EF.Context;
using System.Threading.Tasks;

namespace Marketplace.Infra.Transactions
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MarketplaceContext _context;

        public UnitOfWork(MarketplaceContext context)
        {
            _context = context;
        }

        public void Commit() => _context.SaveChanges();

        public Task<int> CommitAsync() => _context.SaveChangesAsync();
    }
}
