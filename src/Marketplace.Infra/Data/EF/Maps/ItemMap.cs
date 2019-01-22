using Marketplace.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Marketplace.Infra.Data.EF.Maps
{
    public class ItemMap : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasKey(_ => _.Id);

            builder.ToTable(nameof(Item));

            builder.HasOne(_ => _.Option)
                .WithMany(_ => _.Items);
        }
    }
}
