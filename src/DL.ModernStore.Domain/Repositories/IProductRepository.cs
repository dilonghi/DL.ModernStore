using DL.ModernStore.Domain.Entities;
using System;
using System.Collections.Generic;

namespace DL.ModernStore.Domain.Repositories
{
    public interface IProductRepository
    {
        Product Get(Guid id);
        IEnumerable<Product> Get(List<Guid> ids);

    }
}
