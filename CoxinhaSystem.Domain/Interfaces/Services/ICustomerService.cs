using CoxinhaSystem.Domain.Models;

namespace CoxinhaSystem.Domain.Interfaces.Services
{
    public interface ICustomerService
    {
        Customer GetByPhone(string phoneNumber);
        Customer GetByPhoneComplete(string phoneNumber);
        Customer GetCompleteById(int id);
        int SaveOrUpdateCustomerByPhone(Customer customer);
    }
}
