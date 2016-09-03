using CoxinhaSystem.Domain.Interfaces.Repositories;
using CoxinhaSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoxinhaSystem.Infra.Data.Repositories
{
    public class AddressRepository : BaseRepository<Address>, IAddressRepository
    {
    }
}
