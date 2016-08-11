using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoxinhaSystem.Domain.Services
{
    public static class ServiceHelper
    {
        public static void ValidateParams(object[] objs)
        {
            foreach (object obj in objs)
            {
                if (obj == null)
                {
                    throw new ArgumentException("Error: invalid/null parameter");
                }
            }
        }
    }
}
