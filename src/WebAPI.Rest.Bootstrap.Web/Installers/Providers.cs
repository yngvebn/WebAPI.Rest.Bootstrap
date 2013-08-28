using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using WebAPI.Rest.Bootstrap.Interfaces.DataProvider;

namespace WebAPI.Rest.Bootstrap.Web.Installers
{
    public class Providers : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly().BasedOn<IProvideDataFor>().WithServiceBase());
        }
    }
}