using System.Collections.Generic;
using RestAPI.Core.Models;
using RestAPI.Core.Attributes;

namespace RestAPI.Web.Models
{
    [Explode("Products")]
    public class ProductsResponse: BaseApiResponse
    {
        public List<ProductResponse> Products { get; set; }
    }
}