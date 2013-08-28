using System;
using System.Web.Http.Routing;
using RestAPI.Core.Models;

namespace RestAPI.Core.LinkProviders
{
    public interface IGenerateLinkTo
    {
        void Generate<T>(Type linkResourceType, string resourceName,T onModel)
            where T : BaseApiResponse;

        IHttpRoute FindHttpRoute(Type linkResourceType);
    }
}