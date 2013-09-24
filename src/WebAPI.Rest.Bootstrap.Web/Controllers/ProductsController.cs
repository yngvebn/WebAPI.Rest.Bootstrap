using System.Web.Http;
using AttributeRouting;
using AttributeRouting.Web.Http;
using WebAPI.Rest.Bootstrap.Core.Models;
using WebAPI.Rest.Bootstrap.Web.Models;

namespace WebAPI.Rest.Bootstrap.Web.Controllers
{
    [RoutePrefix("api/v1")]
    public class ProductsController: ApiController
    {
        [GET("products"), HttpGet]
        public HttpResponseMessage<ProductsResponse> GetProducts()
        {
            return new HttpResponseMessage<ProductsResponse>();
        }

        [PUT("products/{sku}"), HttpPut]
        public HttpResourceMessage<ProductResponse> UpdateProduct(string sku, UpdateProductRequest request)
        {
            return new HttpResourceMessage<ProductResponse>();
        }
        
        [GET("product/{sku}"), HttpGet]
        public HttpResponseMessage<ProductResponse> GetProduct(string sku)
        {
            return new HttpResponseMessage<ProductResponse>();
        }
    }

    public class UpdateProductRequest
    {
        public string Name { get; set; }
    }
}