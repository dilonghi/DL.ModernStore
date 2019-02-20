﻿using DL.ModernStore.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace DL.ModernStore.Infra.Mappings
{
    public class OrderItemMap : EntityTypeConfiguration<OrderItem>
    {
        public OrderItemMap()
        {
            ToTable("OrderItems");
            HasKey(x => x.Id);

            Property(x => x.Price)
                .HasColumnType("money");

            Property(x => x.Quantity);
            HasRequired(x => x.Product);
        }
    }
}
