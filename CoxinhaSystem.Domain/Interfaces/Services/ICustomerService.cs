using CoxinhaSystem.Domain.Models;
using System.Linq;

namespace CoxinhaSystem.Domain.Interfaces.Services
{
    public interface ICustomerService
    {
        IQueryable<Customer> GetComplete();
        Customer GetByPhone(string phoneNumber);
        Customer GetByPhoneComplete(string phoneNumber);
        Customer GetCompleteById(int id);        
        int SaveOrUpdateCustomerByPhone(Customer customer);
        int UpdateComplete(Customer customer);
    }
}
