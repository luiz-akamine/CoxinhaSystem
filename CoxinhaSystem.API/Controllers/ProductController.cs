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
    [RoutePrefix("api/Product")]
    public class ProductController : BaseController<Product>
    {
        private readonly ProductService _productService;

        //Construtor custom quando houver necessidade de ter métodos diferentes da classe base
        public ProductController(IBaseService<Product> baseService, IProductService productService) : base(baseService)
        {
            _productService = productService as ProductService;
        }

        [Route("GetByType")]
        public HttpResponseMessage GetByType(ProductType productType)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _productService.GetByType(productType));
        }
    }
}
