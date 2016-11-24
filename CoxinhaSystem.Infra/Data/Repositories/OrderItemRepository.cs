using CoxinhaSystem.Domain.Interfaces.Repositories;
using CoxinhaSystem.Domain.Models;
using Microsoft.Data.Entity;
using System.Linq;

namespace CoxinhaSystem.Infra.Data.Repositories
{
    public class OrderItemRepository : BaseRepository<OrderItem>, IOrderItemRepository
    {
        public void DeleteItensOfOrder(int orderId)
        {
            //Registros a serem apagados
            var itemsToDelete = (from oi in _context.OrderItems
                                where oi.OrderId == orderId
                                select oi).ToList();

            //Apagando
            _context.OrderItems.RemoveRange(itemsToDelete);
            _context.SaveChanges();
        }
    }
}