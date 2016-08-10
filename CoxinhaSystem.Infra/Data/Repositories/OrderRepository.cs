using System;
using System.Linq;
using CoxinhaSystem.Domain.Interfaces.Repositories;
using CoxinhaSystem.Domain.Models;
using Microsoft.Data.Entity;

namespace CoxinhaSystem.Infra.Data.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public IQueryable<Order> GetComplete()
        {
            var ordersComplete = _context.Orders.Include(x => x.OrderItems);

            return ordersComplete;
        }

        public Order GetCompleteById(int id)
        {
            var ordersComplete = _context.Orders
                .Include(x => x.OrderItems)
                .Where(x => x.Id == id)
                .FirstOrDefault();

            return ordersComplete;
        }
    }
}