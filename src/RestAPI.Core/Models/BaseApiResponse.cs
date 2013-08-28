using System;
using RestAPI.Core.LinkProviders;

namespace RestAPI.Core.Models
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