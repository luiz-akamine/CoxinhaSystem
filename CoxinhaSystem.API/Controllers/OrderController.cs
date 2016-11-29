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
            try
            {
                var orders = _orderService.GetComplete().ToList();

                if (orders == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, orders);
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }            
        }

        [Route("GetCompleteById")]
        public HttpResponseMessage GetCompleteById(int id)
        {
            try
            {
                var order = _orderService.GetCompleteById(id);

                if (order == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, order);
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("GetByCustomer")]
        public HttpResponseMessage GetByCustomer(int customerId)
        {
            try
            {
                var orders = _orderService.GetByCustomer(customerId);

                if (orders == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, orders);
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("GetByPhone")]
        public HttpResponseMessage GetByPhone(string phone)
        {
            try
            {
                var orders = _orderService.GetByPhone(phone).ToList();

                if (orders == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, orders);
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("GetByDtCreation")]
        public HttpResponseMessage GetByDtCreation(DateTime dtBegin, DateTime dtEnd)
        {
            try
            {             
                var orders = _orderService.GetByDtCreation(dtBegin, dtEnd).ToList();

                if (orders == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, orders);
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("GetByDtDelivery")]
        public HttpResponseMessage GetByDtDelivery(DateTime dtBegin, DateTime dtEnd)
        {
            try
            {
                var orders = _orderService.GetByDtDelivery(dtBegin, dtEnd).ToList();

                if (orders == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, orders);
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("GetTotalByPeriod")]
        public HttpResponseMessage GetTotalByPeriod(DateTime dtBegin, DateTime dtEnd)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, _orderService.GetTotalByPeriod(dtBegin, dtEnd));
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("GetMostRequestedProducts")]
        public HttpResponseMessage GetMostRequestedProducts(DateTime dtBegin, DateTime dtEnd, ProductType productType)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, _orderService.GetMostRequestedProducts(dtBegin, dtEnd, productType).ToList());
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("PutComplete")]
        [AcceptVerbs("POST")]
        public HttpResponseMessage PutComplete(Order order)
        {
            try
            {
                //Atualizando ordem e seus itens
                _orderService.UpdateComplete(order);                
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (ArgumentNullException e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
            catch (ArgumentException e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("DeleteComplete")]
        [AcceptVerbs("POST")]
        public HttpResponseMessage DeleteComplete(Order order)
        {
            try
            {
                //Atualizando ordem e seus itens
                _orderService.DeleteComplete(order.Id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (ArgumentNullException e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
            catch (ArgumentException e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
