using CoxinhaSystem.Domain.Interfaces.Services;
using CoxinhaSystem.Domain.Models;
using CoxinhaSystem.Domain.Services;
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
        private readonly PhoneService _phoneService;

        public PhoneController(IPhoneService phoneService)
        {            
               _phoneService = phoneService as PhoneService;
        }


        //APIS

        public HttpResponseMessage Get()
        {
            try
            {
                
                return Request.CreateResponse(HttpStatusCode.OK, _phoneService.GetAll().ToList());
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
                var phone = _phoneService.GetById(id);

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

        public HttpResponseMessage Post(Phone phone)
        {
            try
            {
                _phoneService.Post(phone);
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

        public HttpResponseMessage Put(Phone phone)
        {
            try
            {
                _phoneService.Update(phone);
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
