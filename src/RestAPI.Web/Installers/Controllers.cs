using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using RestAPI.Web.Controllers;

namespace RestAPI.Web.Installers
{
    public class Controllers : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly().BasedOn<IHttpController>().WithServiceAllInterfaces().LifestyleTransient());
        }
    }
}