using CoxinhaSystem.Domain.Interfaces.Infra;
using CoxinhaSystem.Domain.Interfaces.Repositories;
using CoxinhaSystem.Domain.Interfaces.Services;
using CoxinhaSystem.Domain.Models;
using Microsoft.Practices.ServiceLocation;
using System.Linq;

namespace CoxinhaSystem.Domain.Services
{
    public class OrderService : BaseService<Order>, IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IBaseRepository<Order> entityRepository, IUnityOfWork unitOfWork) : base(entityRepository, unitOfWork)
        {
            //Necessário criar desta maneira para adquirir as rotinas customizadas diferentes do baseRepository
            _orderRepository = ServiceLocator.Current.GetInstance<IOrderRepository>();
        }

        public IQueryable<Order> GetComplete()
        {
            return _orderRepository.GetComplete();
        }

        public Order GetCompleteById(int id)
        {
            return _orderRepository.GetCompleteById(id);
        }
    }
}
