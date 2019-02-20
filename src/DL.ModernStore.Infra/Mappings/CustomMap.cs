using DL.ModernStore.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace DL.ModernStore.Infra.Mappings
{
    public  class CustomMap : EntityTypeConfiguration<Customer>
    {
        public CustomMap()
        {
            ToTable("Customers");
            HasKey(x => x.Id);

            Property(x => x.Name.FirtName)
                .IsRequired()
                .HasMaxLength(60)
                .HasColumnName("FirtName");

            Property(x => x.Name.LastName)
                .IsRequired()
                .HasMaxLength(60)
                .HasColumnName("LastName");

            Property(x => x.Document.Number)
                .IsRequired()
                .HasMaxLength(11)
                .IsFixedLength()
                .HasColumnName("Document");

            Property(x => x.Email.Address)
                .IsRequired()
                .HasMaxLength(160)
                .HasColumnName("Email");

            Property(x => x.BirthDate)
                .IsRequired();

            HasRequired(x => x.User);
             
        }
    }
}
