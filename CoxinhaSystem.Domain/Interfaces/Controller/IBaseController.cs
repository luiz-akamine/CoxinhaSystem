using CoxinhaSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CoxinhaSystem.Domain.Interfaces.Controller
{
    public interface IBaseController<TEntity>
    {
        HttpResponseMessage Get();
        HttpResponseMessage Get(int id);
        HttpResponseMessage Post(TEntity obj);
        HttpResponseMessage Put(TEntity obj);
    }
}
