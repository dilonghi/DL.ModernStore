using DL.ModernStore.Domain.Entities;
using DL.ModernStore.Domain.Repositories;
using DL.ModernStore.Infra.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.ModernStore.Infra.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ModernStoreDataContext _context;

        public OrderRepository(ModernStoreDataContext context)
        {
            _context = context;
        }

        public void Save(Order order)
        {
            _context.Orders.Add(order);
        }
    }
}
