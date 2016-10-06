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
    [RoutePrefix("api/Customer")]
    public class CustomerController : BaseController<Customer>
    {
        private readonly CustomerService _customerService;

        //Construtor custom quando houver necessidade de ter métodos diferentes da classe base
        public CustomerController(IBaseService<Customer> baseService, ICustomerService customerService) : base(baseService)
        {
            _customerService = customerService as CustomerService;
        }

        //APIs
        [Route("GetComplete")]
        public HttpResponseMessage GetComplete()
        {
            try
            {
                var customers = _customerService.GetComplete().ToList();

                if (customers == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, customers);
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
                var customer = _customerService.GetCompleteById(id);

                if (customer == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, customer);
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Route("GetByPhone")]
        public HttpResponseMessage GetByPhone(string phoneNumber)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _customerService.GetByPhone(phoneNumber));
        }

        [Route("GetByPhoneComplete")]
        public HttpResponseMessage GetByPhoneComplete(string phoneNumber)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _customerService.GetByPhoneComplete(phoneNumber));
        }

        [Route("SaveOrUpdateCustomerByPhone")]
        public HttpResponseMessage SaveOrUpdateCustomerByPhone(Customer customer)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _customerService.SaveOrUpdateCustomerByPhone(customer));
        }

        [Route("UpdateComplete")]
        public HttpResponseMessage UpdateComplete(Customer customer)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _customerService.UpdateComplete(customer));
        }
    }
}
