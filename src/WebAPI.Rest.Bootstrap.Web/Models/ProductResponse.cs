using WebAPI.Rest.Bootstrap.Core.Linking;
using WebAPI.Rest.Bootstrap.Core.Models;
using WebAPI.Rest.Bootstrap.Implementations.LinkProviders;

namespace WebAPI.Rest.Bootstrap.Web.Models
{
    [LinksTo(typeof(ManufacturerResponse), "manufacturer")]
    public class ProductResponse: BaseApiResponse
    {
        public string Sku { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string Manufacturer { get; set; }
        public decimal ListPrice { get; set; }
    }
}