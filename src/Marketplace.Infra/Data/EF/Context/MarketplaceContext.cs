using Marketplace.Domain.Entities;
using Marketplace.Infra.Data.EF.Maps;
using Marketplace.Shared;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Infra.Data.EF.Context
{
    public class MarketplaceContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Settings.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
