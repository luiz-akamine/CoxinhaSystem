using CoxinhaSystem.Domain.Models;

namespace CoxinhaSystem.Domain.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        Customer GetByPhone(string phoneNumber);
        Customer GetByPhoneComplete(string phoneNumber);
    }
}
