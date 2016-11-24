using CoxinhaSystem.Domain.Models;

namespace CoxinhaSystem.Domain.Interfaces.Repositories
{
    public interface IOrderItemRepository 
    {
        void DeleteItensOfOrder(int orderId);
    }
}
