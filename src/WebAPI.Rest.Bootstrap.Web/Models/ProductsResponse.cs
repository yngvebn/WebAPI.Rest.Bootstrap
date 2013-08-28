using System.Collections.Generic;
using WebAPI.Rest.Bootstrap.Core.Attributes;
using WebAPI.Rest.Bootstrap.Core.Models;

namespace WebAPI.Rest.Bootstrap.Web.Models
{
    [Explode("Products")]
    public class ProductsResponse: BaseApiResponse
    {
        public List<ProductResponse> Products { get; set; }
    }
}