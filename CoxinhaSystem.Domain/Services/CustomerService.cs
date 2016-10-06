using System;
using CoxinhaSystem.Domain.Interfaces.Infra;
using CoxinhaSystem.Domain.Interfaces.Repositories;
using CoxinhaSystem.Domain.Interfaces.Services;
using CoxinhaSystem.Domain.Models;
using Microsoft.Practices.ServiceLocation;
using System.Linq;

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

        public IQueryable<Customer> GetComplete()
        {
            return _customerRepository.GetComplete();
        }

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

        public int UpdateComplete(Customer customer)
        {
            //Checando se é cliente existe no banco de dados
            if (customer.Id <= 0)
            {
                throw new Exception("customer not exists");
            }            
            else
            {
                try
                {
                    //Atualizando cliente
                    Update(customer);

                    //Criando serviço de endereço
                    IBaseRepository<Address> repAdr = (IBaseRepository<Address>)ServiceLocator.Current.GetInstance<IAddressRepository>();
                    IBaseService<Address> adrService = new BaseService<Address>(repAdr, _unitOfWork);

                    //Verificando se há endereço a ser atualizado
                    if (customer.Addresses != null)
                    {
                        if (customer.Addresses.Count > 0)
                        { 
                            if (customer.Addresses[0].Id <= 0)
                            {
                                //Criar novo endereço
                                adrService.Post(customer.Addresses[0]);
                            }
                            else
                            {
                                //Atualizar
                                adrService.Update(customer.Addresses[0]);
                            }
                        }
                    }

                    //Criando serviço de telefone
                    IBaseRepository<Phone> repPhone = (IBaseRepository<Phone>)ServiceLocator.Current.GetInstance<IPhoneRepository>();
                    IBaseService<Phone> phoneService = new BaseService<Phone>(repPhone, _unitOfWork);

                    //Verificando se há telefone a ser atualizado
                    if (customer.Phones != null)
                    {
                        if (customer.Phones.Count > 0)
                        { 
                            if (customer.Phones[0].Id <= 0)
                            {
                                //Criar novo endereço
                                phoneService.Post(customer.Phones[0]);
                            }
                            else
                            {
                                //Atualizar
                                phoneService.Update(customer.Phones[0]);
                            }
                        }
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
}