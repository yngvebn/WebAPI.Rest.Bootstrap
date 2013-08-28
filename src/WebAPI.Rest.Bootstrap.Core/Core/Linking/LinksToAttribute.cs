using System;
using System.Web.Http.Routing;
using WebAPI.Rest.Bootstrap.Core.Models;

namespace WebAPI.Rest.Bootstrap.Core.Linking
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class LinksToAttribute: Attribute
    {
        public LinksToAttribute(LinkTo linkType)
        {
            LinkType = linkType;
        }

        public LinksToAttribute(Type responseType, string name)
        {
            LinkType = LinkTo.Resource;
            ResponseType = responseType;
            Name = name;
        }

        public Type ResponseType { get; private set; }

        public string Name { get; set; }

        public LinkTo LinkType { get; private set; }

        public Link GetLink(IHttpRoute linkRoute, object o)
        {
            return new Link(Name, RouteHelpers.Link(linkRoute.RouteTemplate, o));
        }
    }
}