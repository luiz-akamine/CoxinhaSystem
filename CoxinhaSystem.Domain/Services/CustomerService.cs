using System;
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

        //Métodos adicionais além da classe base 
        public Customer GetByPhone(string phoneNumber)
        {
            //regras de negócio...
            //
            //            
            return _customerRepository.GetByPhone(phoneNumber);
        }

        //Métodos adicionais além da classe base 
        public Customer GetByPhoneComplete(string phoneNumber)
        {
            //regras de negócio...
            //
            //            
            return _customerRepository.GetByPhoneComplete(phoneNumber);
        }

        public Customer GetCompleteById(int id)
        {
            return _customerRepository.GetCompleteById(id);
        }

        public int SaveOrUpdateCustomerByPhone(Customer customer)
        {
            //Localizando cliente pelo telefone
            Customer customerSearch = GetByPhoneComplete(customer.Phones[0].PhoneNumber);

            //Criando serviço de endereço
            IBaseRepository<Address> repAdr = (IBaseRepository<Address>)ServiceLocator.Current.GetInstance<IAddressRepository>();
            IBaseService<Address> adrService = new BaseService<Address>(repAdr, _unitOfWork);
            
            try
            {
                if (customerSearch != null)
                {                    
                    //Atualizar
                    customer.Id = customerSearch.Id;
                    customer.Addresses[0].CustomerId = customerSearch.Id;
                    customer.Phones[0].CustomerId = customerSearch.Id;

                    // 1) Nome                              
                    Update(customer);

                    // 2) Endereço                                 
                    if (customerSearch.Addresses.Count > 0)
                    {
                        //Endereço já existe. Atualizar
                        //customer.Addresses[0].Id = customerSearch.Addresses[0].Id;
                        customerSearch.Addresses[0].AddressName = customer.Addresses[0].AddressName;
                        customerSearch.Addresses[0].CEP = customer.Addresses[0].CEP;
                        customerSearch.Addresses[0].City = customer.Addresses[0].City;
                        customerSearch.Addresses[0].Complement = customer.Addresses[0].Complement;
                        customerSearch.Addresses[0].District = customer.Addresses[0].District;
                        customerSearch.Addresses[0].MainAddress = customer.Addresses[0].MainAddress;
                        customerSearch.Addresses[0].Number = customer.Addresses[0].Number;
                        customerSearch.Addresses[0].State = customer.Addresses[0].State;
                        adrService.Update(customerSearch.Addresses[0]);
                    }
                    else
                    {
                        //Cadastrar endereço                                        
                        adrService.Post(customer.Addresses[0]);
                    }
                }
                else
                {
                    //Cadastrar                    
                    Post(customer);
                }                
            }
            catch (Exception e)
            {                
                throw new Exception(e.Message);
            }
            return customer.Id;            
        }
    }
}