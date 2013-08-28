using System;
using System.Web.Http.Routing;
using WebAPI.Rest.Bootstrap.Core.Linking;
using WebAPI.Rest.Bootstrap.Interfaces.LinkProvider;

namespace WebAPI.Rest.Bootstrap.Implementations.LinkProviders
{
    public class MarkerClass: IGenerateLinksFor<object, object>
    {
        public void Generate(LinksToAttribute linkResource, object model, IHttpRoute linkRoute)
        {
            throw new NotImplementedException("MarkerClass");
        }
    }
}