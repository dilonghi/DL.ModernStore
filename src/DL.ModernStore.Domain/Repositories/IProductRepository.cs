using DL.ModernStore.Domain.Commands.Results;
using DL.ModernStore.Domain.Entities;
using System;
using System.Collections.Generic;

namespace DL.ModernStore.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Product Get(Guid id);
        IEnumerable<GetProductListCommandResult> Get();

    }
}
