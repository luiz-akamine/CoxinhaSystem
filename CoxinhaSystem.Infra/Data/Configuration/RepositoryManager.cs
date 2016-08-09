using CoxinhaSystem.Domain.Interfaces.Infra;
using CoxinhaSystem.Infra.Data.Context;
using System.Web;

namespace CoxinhaSystem.Infra.Data.Configuration
{
    //Classe para adquirir contexto de forma singleton
    public class RepositoryManager : IRepositoryManager
    {
        public const string HttpCtxt = "HttpContext";

        public CoxinhaContext Context
        {
            get
            {                
                if (HttpContext.Current.Items[HttpCtxt] == null)
                {
                    HttpContext.Current.Items[HttpCtxt] = new CoxinhaContext();
                }
                return (HttpContext.Current.Items[HttpCtxt] as CoxinhaContext);                
            }
        }

        public void Dispose()
        {
            if (HttpContext.Current.Items[HttpCtxt] != null)
            {
                (HttpContext.Current.Items[HttpCtxt] as CoxinhaContext).Dispose();
            }
        }
    }
}