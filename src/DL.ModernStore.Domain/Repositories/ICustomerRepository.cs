using DL.ModernStore.Domain.Entities;
using System;

namespace DL.ModernStore.Domain.Repositories
{
    public interface ICustomerRepository 
    {
        Customer Get(Guid id);
        Customer Get(string document);
         
        Customer GetByUserId(Guid id);
        void Update(Customer customer);

        bool DocumentExists(string document);

        void Save(Customer costumer);
    }
}
