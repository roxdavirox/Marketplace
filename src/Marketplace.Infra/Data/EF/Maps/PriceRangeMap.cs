using Marketplace.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Marketplace.Infra.Data.EF.Maps
{
    public class PriceRangeMap : IEntityTypeConfiguration<PriceRange>
    {
        public void Configure(EntityTypeBuilder<PriceRange> builder)
        {
            builder.ToTable(nameof(PriceRange));
            builder.HasKey(_ => _.Id);

        }
    }
}
