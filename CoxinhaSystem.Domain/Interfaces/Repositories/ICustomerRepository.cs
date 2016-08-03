using CoxinhaSystem.Domain.Models;

namespace CoxinhaSystem.Domain.Interfaces.Repositories
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        Customer GetByPhone(string phoneNumber);
    }
}
