using CoxinhaSystem.Domain.Models;
using CoxinhaSystem.Domain.Services;

namespace CoxinhaSystem.Domain.Interfaces.Services
{
    public interface ICustomerService
    {
        Customer GetByPhone(string phoneNumber);
    }
}
