using CoxinhaSystem.Domain.Interfaces.Repositories;
using CoxinhaSystem.Domain.Models;

namespace CoxinhaSystem.Infra.Data.Repositories
{
    public class OrderRepository: BaseRepository<Order>, IOrderRepository
    {
    }
}