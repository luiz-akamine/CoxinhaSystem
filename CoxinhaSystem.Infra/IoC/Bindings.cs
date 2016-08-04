using CommonServiceLocator.SimpleInjectorAdapter;
using CoxinhaSystem.Domain.Interfaces.Infra;
using CoxinhaSystem.Domain.Interfaces.Repositories;
using CoxinhaSystem.Domain.Interfaces.Services;
using CoxinhaSystem.Domain.Services;
using CoxinhaSystem.Infra.Data.Configuration;
using CoxinhaSystem.Infra.Data.Repositories;
using Microsoft.Practices.ServiceLocation;
using SimpleInjector;

namespace CoxinhaSystem.Infra.IoC
{
    // install-package simpleinjector
    // install-package commonservicelocator -version 1.3.0
    // install-package commonservicelocator.simpleinjectoradapter
    public static class Bindings
    {        
        public static void Start(Container container)
        {
            //Infra
            container.Register<IRepositoryManager, RepositoryManager>();
            container.Register<IUnityOfWork, UnitOfWork>(Lifestyle.Scoped);
            container.Register(typeof(IBaseRepository<>), typeof(BaseRepository<>), Lifestyle.Scoped);
            container.Register(typeof(ICustomerRepository), typeof(CustomerRepository), Lifestyle.Scoped);
            container.Register(typeof(IOrderItemRepository), typeof(OrderItemRepository), Lifestyle.Scoped);
            container.Register(typeof(IOrderRepository), typeof(OrderRepository), Lifestyle.Scoped);
            container.Register(typeof(IPhoneRepository), typeof(PhoneRepository), Lifestyle.Scoped);
            container.Register(typeof(IProductRepository), typeof(ProductRepository), Lifestyle.Scoped);

            //Services
            container.Register(typeof(ICustomerService), typeof(CustomerService), Lifestyle.Scoped);
            container.Register(typeof(IPhoneService), typeof(PhoneService), Lifestyle.Scoped);

            //API
            //to do

            //Service Locator
            ServiceLocator.SetLocatorProvider(() => new SimpleInjectorServiceLocatorAdapter(container));
        }
    }
}