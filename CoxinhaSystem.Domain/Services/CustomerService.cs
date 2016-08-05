using CoxinhaSystem.Domain.Interfaces.Services;
using CoxinhaSystem.Domain.Models;
using CoxinhaSystem.Domain.Interfaces.Repositories;
using System;
using System.Linq;
using CoxinhaSystem.Domain.Interfaces.Infra;

namespace CoxinhaSystem.Domain.Services
{
    public class CustomerService : BaseService<Customer>, ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(IBaseRepository<Customer> entityRepository, IUnityOfWork unitOfWork) : base(entityRepository, unitOfWork)
        {
            _customerRepository = entityRepository as ICustomerRepository;
        }

        //Métodos adicionais 
        public Customer GetByPhone(string phoneNumber)
        {
            //regras de negócio...
            //
            //

            return _customerRepository.GetByPhone(phoneNumber);
        }
    }
}