using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Routing;
using RestAPI.Core.Exceptions;
using RestAPI.Core.Models;

namespace RestAPI.Core.LinkProviders
{
    public class GenerateLinkTo: IGenerateLinkTo
    {
        private readonly HttpRouteCollection _routeCollection;
        private readonly IEnumerable<IHttpController> _controllers;

        public GenerateLinkTo(HttpRouteCollection routeCollection, IEnumerable<IHttpController> controllers)
        {
            _routeCollection = routeCollection;
            _controllers = controllers;
        }

        public IHttpRoute FindHttpRoute(Type linkResourceType)
        {
            var action = FindActionThatReturnsModel(linkResourceType);
            if (action == null)
            {
                throw new ActionNotFoundForModel(linkResourceType);
            }
            var route = FindRouteThatPointsTo(action);
            return route;
        }

        public void Generate<T>(Type linkResourceType, string resourceName, T onModel)
            where T : BaseApiResponse
        {
            var route = FindHttpRoute(linkResourceType);
            onModel.AddLink(resourceName, ConstructUrl(onModel, route));
                
        }

        private string ConstructUrl<T>(T onModel, IHttpRoute route)
        {
            return RouteHelpers.Link(route.RouteTemplate, onModel);
        }

        private IHttpRoute FindRouteThatPointsTo(MethodInfo action)
        {
            foreach(var route in _routeCollection)
            {
                if((route.Defaults["controller"]+"Controller").Equals(action.DeclaringType.Name, StringComparison.InvariantCultureIgnoreCase) &&
                    route.Defaults["action"].ToString().Equals(action.Name, StringComparison.InvariantCultureIgnoreCase))
                {
                    return route;
                }
            }
            throw new ApplicationException("Route not found for " + action.Name + " on " + action.DeclaringType.Name);
        }

        private MethodInfo FindActionThatReturnsModel(Type linkResourceType)
          
        {
            foreach(var controller in _controllers)
            {
                var method = controller.GetType().GetMethods().SingleOrDefault(action => action.ReturnType == typeof(HttpResponseMessage<>).MakeGenericType(linkResourceType));
                if (method != null)
                    return method;
            }
            return null;
        }
    }
}