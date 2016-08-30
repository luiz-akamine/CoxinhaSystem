using CoxinhaSystem.Domain.Interfaces.Infra;
using CoxinhaSystem.Domain.Interfaces.Repositories;
using CoxinhaSystem.Domain.Interfaces.Services;
using CoxinhaSystem.Domain.Models;
using Microsoft.Practices.ServiceLocation;
using System.Linq;

namespace CoxinhaSystem.Domain.Services
{
    public class ProductService : BaseService<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IBaseRepository<Product> entityRepository, IUnityOfWork unitOfWork) : base(entityRepository, unitOfWork)
        {
            //Necessário criar desta maneira para adquirir as rotinas customizadas diferentes do baseRepository
            _productRepository = ServiceLocator.Current.GetInstance<IProductRepository>();
        }

        public IQueryable<Product> GetByType(ProductType productType)
        {
            ServiceHelper.ValidateParams(new object[] { productType });

            return _productRepository.GetByType(productType);            
        }
    }
}
