using CoxinhaSystem.Domain.Models;
using System.Linq;

namespace CoxinhaSystem.Domain.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        IQueryable<Customer> GetComplete();
        Customer GetByPhone(string phoneNumber);
        Customer GetByPhoneComplete(string phoneNumber);
        Customer GetCompleteById(int id);        
    }
}
