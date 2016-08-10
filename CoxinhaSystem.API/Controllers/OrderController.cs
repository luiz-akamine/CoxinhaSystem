using CoxinhaSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CoxinhaSystem.Domain.Interfaces.Services;

namespace CoxinhaSystem.API.Controllers
{
    [RoutePrefix("api/Order")]
    public class OrderController : BaseController<Order>
    {
        public OrderController(IBaseService<Order> baseService) : base(baseService)
        {
        }
    }
}
