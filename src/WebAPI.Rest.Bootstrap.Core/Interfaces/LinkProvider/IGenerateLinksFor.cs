using System.Web.Http.Routing;
using WebAPI.Rest.Bootstrap.Core.Linking;
using WebAPI.Rest.Bootstrap.Implementations.LinkProviders;

namespace WebAPI.Rest.Bootstrap.Interfaces.LinkProvider
{
    public interface IGenerateLinksFor<TLinkResource, in TOnModel> : IGenerateLinksFor
    {
        void Generate(LinksToAttribute linkResource, TOnModel model, IHttpRoute linkRoute);
    }

    public interface IGenerateLinksFor
    {

    }
}