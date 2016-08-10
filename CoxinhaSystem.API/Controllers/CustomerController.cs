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

        [Route("GetByPhone")]
        public HttpResponseMessage GetByPhone(string phoneNumber)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _customerService.GetByPhone(phoneNumber));
        }
    }
}
