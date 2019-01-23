using Marketplace.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Marketplace.Infra.Data.EF.Maps
{
    public class OptionMap : IEntityTypeConfiguration<Option>
    {
        public void Configure(EntityTypeBuilder<Option> builder)
        {
            builder.HasKey(p => p.Id);

            builder.ToTable(nameof(Option));

            builder.HasOne(p => p.Product)
                .WithMany(p => p.Options)
                .HasForeignKey("IdProduct");
        }
    }
}
