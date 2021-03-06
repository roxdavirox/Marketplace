﻿using Marketplace.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Marketplace.Infra.Data.EF.Maps
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.ToTable(nameof(Product));

            builder.HasOne(_ => _.Option)
                .WithMany(_ => _.Products)
                .OnDelete(DeleteBehavior.SetNull)
                .HasForeignKey("IdOption");
        }
    }
}
