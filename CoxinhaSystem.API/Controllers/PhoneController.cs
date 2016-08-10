using CoxinhaSystem.Domain.Interfaces.Services;
using CoxinhaSystem.Domain.Models;
using CoxinhaSystem.Domain.Services;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CoxinhaSystem.API.Controllers
{
    [RoutePrefix("api/Phone")]
    public class PhoneController : BaseController<Phone>
    {
        public PhoneController(IBaseService<Phone> baseService) : base(baseService)
        {
        }
    }
}
