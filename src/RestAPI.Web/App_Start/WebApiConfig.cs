using System.Linq;
using System.Web.Http;
using System.Web.Http.Filters;
using Castle.Core.Internal;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using Castle.Windsor.Installer;
using RestAPI.Core;
using RestAPI.Core.Castle;
using RestAPI.Core.Models;

namespace RestAPI.Web.App_Start
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new WindsorContainer();
            config.DependencyResolver = new WindsorDependencyResolver(container);
            container.Kernel.Resolver.AddSubResolver(new ListResolver(container.Kernel));
            container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel));

            
            container.Install(FromAssembly.Containing<BaseApiResponse>());
            container.Install(FromAssembly.This());

            container.Register(Component.For<System.Web.Http.HttpRouteCollection>().Instance(config.Routes));
            container.Register(Component.For<HttpConfiguration>().Instance(config));

            container.ResolveAll(typeof(IFilter)).Cast<IFilter>().ForEach(config.Filters.Add);
        }
    }
}
