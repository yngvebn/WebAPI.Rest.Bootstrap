using System.Web.Http;
using AttributeRouting;
using AttributeRouting.Web.Http;
using RestAPI.Core.Models;
using RestAPI.Web.Models;

namespace RestAPI.Web.Controllers
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
        public HttpResponseMessage<ManufacturerResponse> GetManufacturer(int id)
        {
            return new HttpResponseMessage<ManufacturerResponse>();
        }
         
    }
}