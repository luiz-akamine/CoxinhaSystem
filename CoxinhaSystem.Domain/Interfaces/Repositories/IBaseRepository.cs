using System.Linq;

namespace CoxinhaSystem.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        TEntity GetById(int id);
        void Insert(TEntity obj);
        void Update(TEntity obj);
        void Delete(TEntity obj);
        void Delete(int id);
    }
}
