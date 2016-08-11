using CoxinhaSystem.Domain.Models;
using System;
using System.Linq;

namespace CoxinhaSystem.Domain.Interfaces.Repositories
{
    public interface IOrderRepository
    {        
        IQueryable<Order> GetComplete();
        IQueryable<Order> GetByDtCreation(DateTime dtBegin, DateTime dtEnd);
        IQueryable<Order> GetByDtDelivery(DateTime dtBegin, DateTime dtEnd);
        IQueryable<Order> GetByCustomer(int customerId);
        IQueryable<Order> GetByPhone(string phone);
        Order GetCompleteById(int id);
    }
}
