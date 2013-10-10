using System;
using System.Web.Http.Routing;
using WebAPI.Rest.Bootstrap.Core.Models;
using WebAPI.Rest.Bootstrap.Implementations.LinkProviders;

namespace WebAPI.Rest.Bootstrap.Interfaces.LinkProvider
{
    public interface ILinkGenerator
    {
        void Generate<T>(Type linkResourceType, string resourceName,T onModel, LinkArgumentStyle linkArgumentStyle)
            where T : BaseApiResponse;

        IHttpRoute FindHttpRoute(Type linkResourceType);
    }
}