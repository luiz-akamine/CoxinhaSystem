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
        //IQueryable<Order> GetByDtCreation(DateTime dtStart, DateTime dtEnd);
        //IQueryable<Order> GetByDeliveryDate(DateTime dtStart, DateTime dtEnd);
        IQueryable<Order> GetComplete();
        IQueryable<Order> GetCompleteById(int id);
    }
}
