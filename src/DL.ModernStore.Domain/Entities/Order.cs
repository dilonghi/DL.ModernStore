using DL.ModernStore.Domain.Enums;
using DL.ModernStores.Shared.Entities;
using FluentValidator;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DL.ModernStore.Domain.Entities
{
    public class Order : Entity
    {
        protected Order()
        {
        }

        public Order(Customer customer, decimal deliveryFee, decimal discount)
        {
            Customer = customer;
            CreateDate = DateTime.Now;
            Number = Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
            Status = EOrderStatus.Created;
            Items = new List<OrderItem>();
            DeliveryFee = deliveryFee;
            Discount = discount;

            new ValidationContract<Order>(this)
                .IsGreaterThan(x => x.DeliveryFee, 0)
                .IsGreaterThan(x => x.Discount, -1);
        }

        public Customer Customer { get; private set; }
        public DateTime CreateDate { get; private set; }
        public string Number { get; private set; }
        public EOrderStatus Status { get; private set; }
        public ICollection<OrderItem> Items { get; private set; }
        public decimal DeliveryFee { get; private set; }
        public decimal Discount { get; private set; }

        public decimal SubTotal() => Items.Sum(x => x.Total());
        public decimal Total() => SubTotal() + DeliveryFee - Discount;
        

        public void AddItem(OrderItem item)
        {
            AddNotifications(item.Notifications);
            if(item.IsValid())
                Items.Add(item);
        }
            
        public void Place()
        {

        }
    }
}
