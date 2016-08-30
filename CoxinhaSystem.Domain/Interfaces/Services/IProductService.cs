using CoxinhaSystem.Domain.Models;
using System.Linq;

namespace CoxinhaSystem.Domain.Interfaces.Services
{
    public interface IProductService
    {
        IQueryable<Product> GetByType(ProductType productType);
    }
}
