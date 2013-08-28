using WebAPI.Rest.Bootstrap.Core.Linking;
using WebAPI.Rest.Bootstrap.Implementations.LinkProviders;

namespace WebAPI.Rest.Bootstrap.Core.Models
{
    [LinksTo(LinkTo.Self)]
    public abstract class BaseApiResponse
    {
        public dynamic Links { get; set; }

        public void AddLink(string name, string url)
        {
            Links[name] = url;
        }

        public void AddLink(Link link)
        {
            AddLink(link.Name, link.Url);
        }


        protected BaseApiResponse()
        {
            Links = new DynamicLinkCollection();
        }
    }
}