using System;
using System.Collections.Generic;
using System.Web.Http.Routing;
using RestAPI.Core.Models;

namespace RestAPI.Core.LinkProviders
{
    public enum LinkTo
    {
        Resource,
        Self,
        Parent
    }

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