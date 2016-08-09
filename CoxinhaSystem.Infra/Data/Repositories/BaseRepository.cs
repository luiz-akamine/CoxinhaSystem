using CoxinhaSystem.Domain.Interfaces.Infra;
using CoxinhaSystem.Domain.Interfaces.Repositories;
using CoxinhaSystem.Domain.Models;
using CoxinhaSystem.Infra.Data.Configuration;
using CoxinhaSystem.Infra.Data.Context;
using Microsoft.Data.Entity;
using Microsoft.Practices.ServiceLocation;
using System.Linq;

namespace CoxinhaSystem.Infra.Data.Repositories
{
    public class BaseRepository<TEntity>: IBaseRepository<TEntity> where TEntity : EntityBase
    {
        protected readonly CoxinhaContext _context;

        public BaseRepository()
        {
            // install-package commonservicelocator
            var repositoryManager = (RepositoryManager)ServiceLocator.Current.GetInstance<IRepositoryManager>();
            _context = repositoryManager.Context;
        }

        public void Delete(int id)
        {
            TEntity obj = GetById(id);
            if (obj != null)
            {
                Delete(obj);
            }
        }

        public void Delete(TEntity obj)
        {
            _context.Set<TEntity>().Remove(obj);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>();
        }

        public TEntity GetById(int id)
        {
            return _context.Set<TEntity>().Where(x => x.Id == id).FirstOrDefault();
        }

        public void Insert(TEntity obj)
        {
            _context.Set<TEntity>().Add(obj);
        }

        public void Update(TEntity obj)
        {
            //Gambiarra ou Ajuste Técnico??? Sem isso abaixo, não funciona... Ocorre o erro:
            //
            //  'Entidade XXX' cannot be tracked because another instance of this type with the same key 
            //  is already being tracked. For new entities consider using an IIdentityGenerator to generate 
            //  unique key values.
            //
            //Assim, estou "Detachando" a entidade em questão para ser salva
            var entry = _context.ChangeTracker.Entries().Where(x => x.Entity.GetType().Equals(obj.GetType())).FirstOrDefault();
            _context.Entry(entry.Entity).State = EntityState.Detached;
                   
            _context.Entry(obj).State = EntityState.Modified;
        }
    }    
}