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
        Order GetCompleteById(int id);
    }
}
