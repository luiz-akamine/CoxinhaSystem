using System;
using System.Linq;
using CoxinhaSystem.Domain.Interfaces.Repositories;
using CoxinhaSystem.Domain.Models;

namespace CoxinhaSystem.Infra.Data.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public IQueryable<Product> GetByType(ProductType productType)
        {
            var products = _context.Products
                .Where(p => p.ProductType == productType);

            return products;
        }
    }
}