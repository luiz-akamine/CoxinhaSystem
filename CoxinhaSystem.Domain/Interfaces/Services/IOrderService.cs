using CoxinhaSystem.Domain.DTOs;
using CoxinhaSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoxinhaSystem.Domain.Interfaces.Services
{
    public interface IOrderService
    {
        IQueryable<Order> GetComplete();
        IQueryable<Order> GetByDtCreation(DateTime dtBegin, DateTime dtEnd);
        IQueryable<Order> GetByDtDelivery(DateTime dtBegin, DateTime dtEnd);
        IQueryable<Order> GetByCustomer(int customerId);
        IQueryable<Order> GetByPhone(string phone);
        IQueryable<MostRequestedProducts> GetMostRequestedProducts(DateTime dtBegin, DateTime dtEnd, ProductType productType);
        Double GetTotalByPeriod(DateTime dtBegin, DateTime dtEnd);
        Order GetCompleteById(int id);
        void UpdateComplete(Order order);
        void DeleteComplete(int orderId);
    }
}
