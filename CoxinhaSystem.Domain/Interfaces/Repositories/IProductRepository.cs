﻿using CoxinhaSystem.Domain.Models;
using System.Linq;

namespace CoxinhaSystem.Domain.Interfaces.Repositories
{
    public interface IProductRepository 
    {
        IQueryable<Product> GetByType(ProductType productType);
    }
}
