using System;
using System.Linq;
using CoxinhaSystem.Domain.Interfaces.Repositories;
using CoxinhaSystem.Domain.Models;
using Microsoft.Data.Entity;

namespace CoxinhaSystem.Infra.Data.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public IQueryable<Order> GetByCustomer(int customerId)
        {
            var customerOrders = _context.Orders
                .Include(x => x.Customer)
                .Include(x => x.OrderItems)
                .ThenInclude(x => x.Product)
                .Where(x => x.CustomerId == customerId);

            return customerOrders;
        }

        public IQueryable<Order> GetByDtCreation(DateTime dtBegin, DateTime dtEnd)
        {
            return _context.Orders
                .Include(x => x.Customer)
                .Include(x => x.OrderItems)
                .ThenInclude(x => x.Product)
                .Where(x => x.DtCreation >= dtBegin && x.DtCreation >= dtBegin);
        }

        public IQueryable<Order> GetByDtDelivery(DateTime dtBegin, DateTime dtEnd)
        {
            return _context.Orders
                .Include(x => x.Customer)
                .Include(x => x.OrderItems)
                .ThenInclude(x => x.Product)
                .Where(x => x.DeliveryDate >= dtBegin && x.DeliveryDate >= dtBegin);
        }

        public IQueryable<Order> GetByPhone(string phone)
        {
            //adquirindo clientes do phone passado
            var customers = _context.Customers.Where(c => c.Phones.Any(p => p.PhoneNumber == phone));

            //todas ordens
            var orders = GetComplete();
            
            //join de ordens x clientes encontrados pelo telefone
            var phoneOrdersFilter = from o in orders
                                    join c in customers on o.CustomerId equals c.Id                                       
                                    select o;

            return phoneOrdersFilter;
        }

        public IQueryable<Order> GetComplete()
        {
            var ordersComplete = _context.Orders
                .Include(x => x.Customer)
                .Include(x => x.OrderItems)
                .ThenInclude(x => x.Product);

            return ordersComplete;
        }

        public Order GetCompleteById(int id)
        {            
               var ordersComplete = _context.Orders
                .Include(x => x.Customer)
                .Include(x => x.OrderItems)
                .ThenInclude(x => x.Product)
                .Where(x => x.Id == id)
                .FirstOrDefault();
           
            return ordersComplete;
        }
    }
}