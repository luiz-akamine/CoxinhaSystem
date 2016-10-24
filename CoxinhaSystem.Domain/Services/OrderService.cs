using CoxinhaSystem.Domain.Interfaces.Infra;
using CoxinhaSystem.Domain.Interfaces.Repositories;
using CoxinhaSystem.Domain.Interfaces.Services;
using CoxinhaSystem.Domain.Models;
using Microsoft.Practices.ServiceLocation;
using System.Linq;
using System;
using CoxinhaSystem.Domain.DTOs;

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

        public IQueryable<Order> GetByCustomer(int customerId)
        {
            ServiceHelper.ValidateParams(new object[] { customerId });

            return _orderRepository.GetByCustomer(customerId);
        }

        public IQueryable<Order> GetByDtCreation(DateTime dtBegin, DateTime dtEnd)
        {            
            ServiceHelper.ValidateParams(new object[] { dtBegin, dtEnd });

            return _orderRepository.GetByDtCreation(dtBegin, dtEnd);
        }

        public IQueryable<Order> GetByDtDelivery(DateTime dtBegin, DateTime dtEnd)
        {
            ServiceHelper.ValidateParams(new object[] { dtBegin, dtEnd });

            return _orderRepository.GetByDtDelivery(dtBegin, dtEnd);
        }

        public IQueryable<Order> GetByPhone(string phone)
        {
            ServiceHelper.ValidateParams(new object[] { phone });

            return _orderRepository.GetByPhone(phone);
        }

        public IQueryable<Order> GetComplete()
        {
            return _orderRepository.GetComplete();
        }

        public Order GetCompleteById(int id)
        {
            ServiceHelper.ValidateParams(new object[] { id });

            return _orderRepository.GetCompleteById(id);
        }

        public IQueryable<MostRequestedProducts> GetMostRequestedProducts(DateTime dtBegin, DateTime dtEnd, ProductType productType)
        {
            ServiceHelper.ValidateParams(new object[] { dtBegin, dtEnd });

            return _orderRepository.GetMostRequestedProducts(dtBegin, dtEnd, productType);
        }

        public Double GetTotalByPeriod(DateTime dtBegin, DateTime dtEnd)
        {
            ServiceHelper.ValidateParams(new object[] { dtBegin, dtEnd });

            return _orderRepository.GetTotalByPeriod(dtBegin, dtEnd);
        }
    }
}
