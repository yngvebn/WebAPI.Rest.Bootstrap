using System;
using System.Web.Http.Routing;

namespace RestAPI.Core.LinkProviders
{
    public interface IGenerateLinksFor<TLinkResource, in TOnModel> : IGenerateLinksFor
    {
        void Generate(LinksToAttribute linkResource, TOnModel model, IHttpRoute linkRoute);
    }

    public interface IGenerateLinksFor
    {

    }

    public class MarkerClass: IGenerateLinksFor<object, object>
    {
        public void Generate(LinksToAttribute linkResource, object model, IHttpRoute linkRoute)
        {
            throw new NotImplementedException("MarkerClass");
        }
    }
}