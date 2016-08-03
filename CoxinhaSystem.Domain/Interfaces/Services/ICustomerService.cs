using CoxinhaSystem.Domain.Models;

namespace CoxinhaSystem.Domain.Interfaces.Services
{
    public interface ICustomerService
    {
        Customer GetByPhone(string phoneNumber);
    }
}
