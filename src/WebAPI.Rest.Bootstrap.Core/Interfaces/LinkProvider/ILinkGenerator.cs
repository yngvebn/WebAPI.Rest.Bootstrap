using System;
using System.Web.Http.Routing;
using WebAPI.Rest.Bootstrap.Core.Models;

namespace WebAPI.Rest.Bootstrap.Interfaces.LinkProvider
{
    public interface ILinkGenerator
    {
        void Generate<T>(Type linkResourceType, string resourceName,T onModel)
            where T : BaseApiResponse;

        IHttpRoute FindHttpRoute(Type linkResourceType);
    }
}