using CoxinhaSystem.Domain.Interfaces.Services;
using CoxinhaSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CoxinhaSystem.API.Controllers
{
    [RoutePrefix("api/Phone")]
    public class PhoneController : ApiController
    {
        private readonly IPhoneService _phoneService;

        public PhoneController(IPhoneService phoneService)
        {
            _phoneService = phoneService;
        }


        //APIS

        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _phoneService.GetAll().ToList());
        }

        public HttpResponseMessage Get(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _phoneService.GetById(id));
        }

        public HttpResponseMessage Post(Phone phone)
        {
            _phoneService.Post(phone);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        public HttpResponseMessage Put(Phone phone)
        {
            _phoneService.Update(phone);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
