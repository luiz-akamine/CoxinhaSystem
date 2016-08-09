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
    public class CustomerController : ApiController
    {
        private readonly CustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService as CustomerService;
        }
        

        //APIS

        public HttpResponseMessage Get()
        {
            try
            {

                return Request.CreateResponse(HttpStatusCode.OK, _customerService.GetAll().ToList());
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public HttpResponseMessage Get(int id)
        {
            try
            {
                var phone = _customerService.GetById(id);

                if (phone == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, phone);
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public HttpResponseMessage Post(Customer customer)
        {
            try
            {
                _customerService.Post(customer);
                return Request.CreateResponse(HttpStatusCode.Created);
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

        public HttpResponseMessage Put(Customer customer)
        {
            try
            {
                _customerService.Update(customer);
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

        [Route("GetByPhone")]
        public HttpResponseMessage GetByPhone(string phoneNumber)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _customerService.GetByPhone(phoneNumber));
        }
    }
}
