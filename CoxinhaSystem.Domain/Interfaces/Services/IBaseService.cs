using CoxinhaSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoxinhaSystem.Domain.Interfaces.Services
{
    public interface IBaseService<TEntity>
    {
        IQueryable<TEntity> GetAll();
        TEntity GetById(int id);
        void Post(TEntity obj);
        void Update(TEntity obj);
    }
}
