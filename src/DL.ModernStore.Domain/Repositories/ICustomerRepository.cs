﻿using DL.ModernStore.Domain.Entities;
using System;

namespace DL.ModernStore.Domain.Repositories
{
    public interface ICustomerRepository 
    {
        Customer Get(Guid id);
        Customer GetByUserId(Guid id);

    }
}
