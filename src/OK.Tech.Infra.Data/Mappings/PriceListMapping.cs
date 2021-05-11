using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OK.Tech.Domain.Entities;

namespace OK.Tech.Infra.Data.Mappings
{
    public class PriceListMapping : IEntityTypeConfiguration<PriceList>
    {
        public void Configure(EntityTypeBuilder<PriceList> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name).IsRequired().HasMaxLength(200).HasColumnType("VARCHAR(200)");

            builder.Property(p => p.Active).IsRequired();

            builder.ToTable("PriceLists");
        }
    }
}