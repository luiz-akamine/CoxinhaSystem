using CoxinhaSystem.Domain.Interfaces.Services;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CoxinhaSystem.API.Controllers
{
    [RoutePrefix("api/Customer")]
    public class CustomerController : ApiController
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }


        //APIS

        [Route("GetByPhone")]
        public HttpResponseMessage GetByPhone(string phoneNumber)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _customerService.GetByPhone(phoneNumber));
        }
    }
}
