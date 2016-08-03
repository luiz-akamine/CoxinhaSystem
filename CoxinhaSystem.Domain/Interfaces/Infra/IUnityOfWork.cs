using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoxinhaSystem.Domain.Interfaces.Infra
{
    public interface IUnityOfWork
    {
        void Begin();
        void Commit();
    }
}
