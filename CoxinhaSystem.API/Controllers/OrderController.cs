using CoxinhaSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CoxinhaSystem.Domain.Interfaces.Services;
using CoxinhaSystem.Domain.Services;

namespace CoxinhaSystem.API.Controllers
{
    [RoutePrefix("api/Order")]
    public class OrderController : BaseController<Order>
    {
        private readonly OrderService _orderService;

        //Construtor custom quando houver necessidade de ter métodos diferentes da classe base
        public OrderController(IBaseService<Order> baseService, IOrderService orderService) : base(baseService)
        {
            _orderService = orderService as OrderService;
        }


        //APIs
        [Route("GetComplete")]
        public HttpResponseMessage GetComplete()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _orderService.GetComplete().ToList());
        }

        [Route("GetCompleteById")]
        public HttpResponseMessage GetCompleteById(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _orderService.GetCompleteById(id));
        }
    }
}
