using System.Web.Http;
using AttributeRouting;
using AttributeRouting.Web.Http;
using WebAPI.Rest.Bootstrap.Core.Models;
using WebAPI.Rest.Bootstrap.Web.Models;

namespace WebAPI.Rest.Bootstrap.Web.Controllers
{
    [RoutePrefix("api/v1")]
    public class ManufacturersController: ApiController
    {

        [GET("manufacturers"), HttpGet]
        public HttpResponseMessage<ManufacturersResponse> GetManufacturers()
        {
            return new HttpResponseMessage<ManufacturersResponse>();
        }

        [GET("manufacturers/{id}"), HttpGet]
        public HttpResponseMessage<ManufacturerResponse> GetManufacturer(string id)
        {
            return new HttpResponseMessage<ManufacturerResponse>();
        }
         
    }
}