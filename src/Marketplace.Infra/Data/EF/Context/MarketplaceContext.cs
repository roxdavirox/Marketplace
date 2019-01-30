using Marketplace.Domain.Entities;
using Marketplace.Infra.Data.EF.Maps;
using Marketplace.Shared;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Infra.Data.EF.Context
{
    public class MarketplaceContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<PriceInterval> PriceRange { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Settings.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new OptionMap());
            modelBuilder.ApplyConfiguration(new ItemMap());
            modelBuilder.ApplyConfiguration(new PriceMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
