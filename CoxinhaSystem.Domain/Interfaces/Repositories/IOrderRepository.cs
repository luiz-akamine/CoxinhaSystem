using CoxinhaSystem.Domain.Models;
using System.Linq;

namespace CoxinhaSystem.Domain.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        IQueryable<Order> GetComplete();
        Order GetCompleteById(int id);
    }
}
