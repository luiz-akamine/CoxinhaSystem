using CoxinhaSystem.Domain.Interfaces.Infra;
using CoxinhaSystem.Infra.Data.Context;
using Microsoft.Practices.ServiceLocation;

namespace CoxinhaSystem.Infra.Data.Configuration
{
    public class UnitOfWork : IUnityOfWork
    {
        private CoxinhaContext _context;

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Begin()
        {
            var repositoryManager = ServiceLocator.Current.GetInstance<IRepositoryManager>() as RepositoryManager;
            _context = repositoryManager.Context;
        }        
    }
}