using CoxinhaSystem.Domain.Interfaces.Controller;
using CoxinhaSystem.Domain.Interfaces.Services;
using CoxinhaSystem.Domain.Models;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CoxinhaSystem.API.Controllers
{
    public class BaseController<TEntity>: ApiController where TEntity : EntityBase
    {
        private readonly IBaseService<TEntity> _baseService;

        public BaseController(IBaseService<TEntity> baseService)
        {
            _baseService = baseService;
        }


        // APIs

        public HttpResponseMessage Get()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, _baseService.GetAll().ToList());
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
                var phone = _baseService.GetById(id);

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

        public HttpResponseMessage Post(TEntity obj)
        {
            try
            {
                _baseService.Post(obj);
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

        public HttpResponseMessage Put(TEntity obj)
        {
            try
            {
                _baseService.Update(obj);
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
