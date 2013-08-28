using System.Web.Http.Routing;
using RestAPI.Core.LinkProviders;
using RestAPI.Web.Models;

namespace RestAPI.Web.Providers.Links
{
    public class CreateLinkToManufacturerOnProduct: IGenerateLinksFor<ManufacturerResponse,ProductResponse>
    {
        public void Generate(LinksToAttribute linkResource, ProductResponse model, IHttpRoute linkRoute)
        {
            model.AddLink(linkResource.GetLink(linkRoute, new {id = model.Manufacturer + "_Id"}));
        }
    }
}