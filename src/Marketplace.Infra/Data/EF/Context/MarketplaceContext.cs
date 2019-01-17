using Marketplace.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Infra.Data.EF.Context
{
    public class MarketplaceContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}
