using System.Collections.Generic;
using RestAPI.Core.Models;

namespace RestAPI.Web.Models
{
    public class ManufacturersResponse: BaseApiResponse
    {
        public List<ManufacturerResponse> Manufacturers { get; set; }
    }

    public class ManufacturerResponse: BaseApiResponse
    {
    }
}