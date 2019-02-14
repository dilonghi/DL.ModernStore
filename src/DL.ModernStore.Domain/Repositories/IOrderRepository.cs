using DL.ModernStore.Domain.Entities;

namespace DL.ModernStore.Domain.Repositories
{
    public interface IOrderRepository
    {
        void Save(Order order);
    }
}
