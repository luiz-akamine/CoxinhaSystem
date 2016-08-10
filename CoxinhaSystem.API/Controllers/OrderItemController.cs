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
    [RoutePrefix("api/OrderItem")]
    public class OrderItemController : BaseController<OrderItem>
    {
        public OrderItemController(IBaseService<OrderItem> baseService) : base(baseService)
        {
        }
    }
}
