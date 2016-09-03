using CoxinhaSystem.Domain.Interfaces.Services;
using CoxinhaSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace CoxinhaSystem.API.Controllers
{
    [RoutePrefix("api/Address")]
    public class AddressController : BaseController<Address>
    {
        public AddressController(IBaseService<Address> baseService) : base(baseService)
        {
        }
    }
}