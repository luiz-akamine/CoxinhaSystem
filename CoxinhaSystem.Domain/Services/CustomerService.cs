using CoxinhaSystem.Domain.Interfaces.Services;
using CoxinhaSystem.Domain.Models;
using CoxinhaSystem.Domain.Interfaces.Repositories;

namespace CoxinhaSystem.Domain.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository; 
        }

        public Customer GetByPhone(string phoneNumber)
        {
            //regras de negócio...
            //
            //

            return _customerRepository.GetByPhone(phoneNumber);
        }
    }
}