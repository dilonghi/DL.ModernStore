using DL.ModernStore.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace DL.ModernStore.Infra.Mappings
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            ToTable("Products");
            HasKey(x => x.Id);

            Property(x => x.Image)
                .IsRequired()
                .HasMaxLength(1024);
            Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(80);
            Property(x => x.Price);
            Property(x => x.QuantityOnHand);
        }
    }
}
