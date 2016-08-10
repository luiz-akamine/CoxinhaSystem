using CoxinhaSystem.Domain.Interfaces.Infra;
using CoxinhaSystem.Domain.Interfaces.Repositories;
using CoxinhaSystem.Domain.Interfaces.Services;
using CoxinhaSystem.Domain.Models;
using Microsoft.Practices.ServiceLocation;

namespace CoxinhaSystem.Domain.Services
{
    public class CustomerService : BaseService<Customer>, ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;        

        public CustomerService(IBaseRepository<Customer> entityRepository, IUnityOfWork unitOfWork) : base(entityRepository, unitOfWork)
        {
            //Necessário criar desta maneira para adquirir as rotinas customizadas diferentes do baseRepository
            _customerRepository = ServiceLocator.Current.GetInstance<ICustomerRepository>();
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