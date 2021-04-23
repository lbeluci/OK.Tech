using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OK.Tech.Domain.Entities;

namespace OK.Tech.Infra.Data.Mappings
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name).IsRequired().HasMaxLength(200).HasColumnType("VARCHAR(200)");

            builder.Property(p => p.Description).IsRequired().HasMaxLength(1000).HasColumnType("VARCHAR(1000)");

            builder.Property(p => p.Active).IsRequired();

            builder.ToTable("Products");
        }
    }
}