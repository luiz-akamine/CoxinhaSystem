using CoxinhaSystem.Domain.Interfaces.Infra;
using CoxinhaSystem.Domain.Interfaces.Repositories;
using CoxinhaSystem.Domain.Interfaces.Services;
using CoxinhaSystem.Domain.Models;
using System;
using System.Linq;

namespace CoxinhaSystem.Domain.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : EntityBase
    {
        protected readonly IBaseRepository<TEntity> _entityRepository;
        protected readonly IUnityOfWork _unitOfWork;

        public BaseService(IBaseRepository<TEntity> entityRepository, IUnityOfWork unitOfWork)
        {
            _entityRepository = entityRepository;
            _unitOfWork = unitOfWork;
        }


        // Métodos

        public IQueryable<TEntity> GetAll()
        {
            return _entityRepository.GetAll();
        }

        public TEntity GetById(int id)
        {
            return _entityRepository.GetById(id);
        }

        public void Post(TEntity obj)
        {                           
            //Verificando se existe
            if (GetById(obj.Id) != null)
            {
                throw new ArgumentException("object already exists");
            }
            
            _unitOfWork.Begin();
            _entityRepository.Insert(obj);
            _unitOfWork.Commit();
        }

        public void Update(TEntity obj)
        {
            //Checando parâmetro
            if (obj == null)
            {
                throw new ArgumentNullException();
            }
                        
            //Verificando se existe
            if (GetById(obj.Id) == null)
            {
                throw new ArgumentException("object not exists");
            }
                        
            _unitOfWork.Begin();
            _entityRepository.Update(obj);
            _unitOfWork.Commit();
        }
    }
}
