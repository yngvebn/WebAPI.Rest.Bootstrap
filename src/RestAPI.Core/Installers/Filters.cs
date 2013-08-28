using System.Web.Http.Filters;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace RestAPI.Core.Installers
{
    public class Filters : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly().BasedOn<IFilter>().WithServiceAllInterfaces());
        }
    }
}