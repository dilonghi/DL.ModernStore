using DL.ModernStore.Domain.Commands.Results;
using DL.ModernStore.Domain.Entities;
using System;

namespace DL.ModernStore.Domain.Repositories
{
    public interface ICustomerRepository 
    {
        Customer Get(Guid id);
        GetCustomerCommandResult Get(string username);

        Customer GetByUserId(Guid id);
        void Update(Customer customer);

        bool DocumentExists(string document);

        void Save(Customer costumer);
    }
}
