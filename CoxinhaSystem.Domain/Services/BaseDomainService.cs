using CoxinhaSystem.Domain.Interfaces.Infra;
using Microsoft.Practices.ServiceLocation;

namespace CoxinhaSystem.Domain.Services
{
    public class BaseDomainService
    {
        private IUnityOfWork _unityOfWork;

        public virtual void Begin()
        {
            _unityOfWork = ServiceLocator.Current.GetInstance<IUnityOfWork>();
            _unityOfWork.Begin();
        }

        public virtual void Commit()
        {
            _unityOfWork.Commit();
        }
    }
}