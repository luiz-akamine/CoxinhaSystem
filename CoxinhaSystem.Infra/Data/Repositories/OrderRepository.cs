using System;
using System.Linq;
using CoxinhaSystem.Domain.DTOs;
using CoxinhaSystem.Domain.Interfaces.Repositories;
using CoxinhaSystem.Domain.Models;
using Microsoft.Data.Entity;
using System.Collections.Generic;

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
                .Where(x => x.DtCreation >= dtBegin && x.DtCreation <= dtEnd);
        }

        public IQueryable<Order> GetByDtDelivery(DateTime dtBegin, DateTime dtEnd)
        {
            return _context.Orders
                .Include(x => x.Customer)
                .Include(x => x.OrderItems)
                .ThenInclude(x => x.Product)
                .Where(x => x.DeliveryDate >= dtBegin && x.DeliveryDate <= dtEnd)
                .OrderBy(x => x.DeliveryDate);
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
                .ThenInclude(x => x.Phones)
                .Include(x => x.OrderItems)                
                .ThenInclude(x => x.Product);

            return ordersComplete;
        }

        public Order GetCompleteById(int id)
        {            
            var ordersComplete = _context.Orders
                .Include(x => x.Customer)
                .ThenInclude(x => x.Phones)
                .Include(x => x.OrderItems)
                .ThenInclude(x => x.Product)
                .Where(x => x.Id == id)
                .FirstOrDefault();
           
            return ordersComplete;
        }

        public IQueryable<MostRequestedProducts> GetMostRequestedProducts(DateTime dtBegin, DateTime dtEnd, ProductType productType)
        {
            var orderItems = _context.OrderItems
                .Include(_ => _.Product)
                .Include(_ => _.Order)
                .ToList();
            //var orders = GetComplete().Take(100);
            // var products = _context.Products.Take(100);

            //var mostRequestedProducts = from prod in products
            //                            //join o in orders on oi.OrderId equals o.Id
            //                            join oi in orderItems on prod.Id equals oi.ProductId
            //                            //where o.DeliveryDate >= dtBegin && o.DeliveryDate <= dtEnd
            //                            //&& o.Status < Status.Canceled
            //                            //&& prod.ProductType == productType                                        
            //                            group oi by oi.ProductId into g
            //                            let SumQty = g.Sum(_ => _.Qty)
            //                            //orderby SumQty descending
            //                            select new { g.Key, SumQty };
            var mostRequestedProducts = from oi in orderItems
                                        where oi.Order.DeliveryDate >= dtBegin && oi.Order.DeliveryDate <= dtEnd
                                        && oi.Order.Status < Status.Canceled
                                        && oi.Product.ProductType == productType
                                        group oi by oi.Product into g
                                        let SumQty = g.Sum(_ => _.Qty)
                                        orderby SumQty descending
                                        select new MostRequestedProducts { ProductName = g.Key.Name, SumQty = SumQty };
            
            //String a;
            //Double b;
            //foreach (var x in mostRequestedProducts)
            //{
            //    a = x.ProductName;
            //    b = x.SumQty;
            //}
            //group prod_oi by new { prod_oi.prod.Name } into g
            //select new { g.Key.Name, SumQty = g.Sum(_ => _.oi.Qty) };
            //select new MostRequestedProducts() { ProductName = prod.Name, SumQty = oi.Qty }).AsQueryable();

            return mostRequestedProducts.AsQueryable();
        }

        public Double GetTotalByPeriod(DateTime dtBegin, DateTime dtEnd)
        {
            return _context.Orders               
                .Where(x => x.DeliveryDate >= dtBegin && x.DeliveryDate <= dtEnd)
                .Sum(x => x.TotalWithDiscount);
        }
    }
}