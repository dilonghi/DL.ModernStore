using DL.ModernStore.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace DL.ModernStore.Infra.Mappings
{
   public class OrderMap : EntityTypeConfiguration<Order>
    {
        public OrderMap()
        {
            ToTable("Orders");
            HasKey(x => x.Id);

            Property(x => x.CreateDate)
                .IsRequired();

            Property(x => x.DeliveryFee)
                .HasColumnType("money");

            Property(x => x.Discount)
                .HasColumnType("money");

            Property(x => x.Number)
                .IsRequired()
                .HasMaxLength(8)
                .IsFixedLength();

            Property(x => x.Status);
            
            HasMany(x => x.Items);
            HasRequired(x => x.Customer);
        }
    }
}
