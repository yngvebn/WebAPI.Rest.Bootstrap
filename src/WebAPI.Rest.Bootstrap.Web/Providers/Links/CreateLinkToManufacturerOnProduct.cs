using System.Web.Http.Routing;
using WebAPI.Rest.Bootstrap.Core.Linking;
using WebAPI.Rest.Bootstrap.Implementations.LinkProviders;
using WebAPI.Rest.Bootstrap.Interfaces.LinkProvider;
using WebAPI.Rest.Bootstrap.Web.Models;

namespace WebAPI.Rest.Bootstrap.Web.Providers.Links
{
    public class CreateLinkToManufacturerOnProduct: IGenerateLinksFor<ManufacturerResponse,ProductResponse>
    {
        public void Generate(LinksToAttribute linkResource, ProductResponse model, IHttpRoute linkRoute)
        {
            model.AddLink(linkResource.GetLink(linkRoute, new {id = model.Manufacturer + "_Id"}));
        }
    }
}