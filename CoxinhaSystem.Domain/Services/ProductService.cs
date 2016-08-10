using CoxinhaSystem.Domain.Interfaces.Infra;
using CoxinhaSystem.Domain.Interfaces.Repositories;
using CoxinhaSystem.Domain.Interfaces.Services;
using CoxinhaSystem.Domain.Models;
using Microsoft.Practices.ServiceLocation;

namespace CoxinhaSystem.Domain.Services
{
    public class ProductService : BaseService<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IBaseRepository<Product> entityRepository, IUnityOfWork unitOfWork) : base(entityRepository, unitOfWork)
        {
            _productRepository = ServiceLocator.Current.GetInstance<IProductRepository>();
        }
    }
}
