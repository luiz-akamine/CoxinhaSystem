using CoxinhaSystem.Domain.Models;
using System.Linq;

namespace CoxinhaSystem.Domain.Interfaces.Services
{
    public interface IPhoneService
    {
        IQueryable<Phone> GetAll();
        Phone GetById(int id);
        void Post(Phone phone);
        void Put(Phone phone);
    }
}
