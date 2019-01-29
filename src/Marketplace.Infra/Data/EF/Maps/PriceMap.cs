using Marketplace.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Marketplace.Infra.Data.EF.Maps
{
    public class PriceMap : IEntityTypeConfiguration<Price>
    {
        public void Configure(EntityTypeBuilder<Price> builder)
        {
            builder.ToTable(nameof(Price));
            builder.HasKey(_ => _.Id);

            builder.Property(p => p.Index)
                .ValueGeneratedOnAdd();

            builder.HasOne(_ => _.Item)
                .WithMany(_ => _.Prices)
                .HasForeignKey("IdItem");

        }
    }
}
