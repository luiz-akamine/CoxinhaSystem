using CoxinhaSystem.Domain.Interfaces.Repositories;
using CoxinhaSystem.Domain.Models;

namespace CoxinhaSystem.Infra.Data.Repositories
{
    public class ProductRepository: BaseRepository<Product>, IProductRepository
    {
    }
}