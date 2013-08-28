using RestAPI.Core.LinkProviders;
using RestAPI.Core.Models;

namespace RestAPI.Web.Models
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