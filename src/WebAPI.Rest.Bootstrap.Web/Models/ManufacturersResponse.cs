using System.Collections.Generic;
using WebAPI.Rest.Bootstrap.Core.Models;

namespace WebAPI.Rest.Bootstrap.Web.Models
{
    public class ManufacturersResponse: BaseApiResponse
    {
        public List<ManufacturerResponse> Manufacturers { get; set; }
    }
}