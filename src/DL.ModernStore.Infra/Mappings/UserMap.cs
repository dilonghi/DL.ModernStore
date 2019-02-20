using DL.ModernStore.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace DL.ModernStore.Infra.Mappings
{
    public  class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable("Users");
            HasKey(x => x.Id);
         

            Property(x => x.UserName)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("UserName");

            Property(x => x.Password)
                .IsRequired()
                .HasMaxLength(32)
                .IsFixedLength()
                .HasColumnName("Password");

            Property(x => x.Active);
             
        }
    }
}
