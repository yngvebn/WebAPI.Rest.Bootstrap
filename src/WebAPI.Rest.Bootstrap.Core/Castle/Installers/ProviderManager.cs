using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using WebAPI.Rest.Bootstrap.Interfaces.DataProvider;

namespace WebAPI.Rest.Bootstrap.Castle.Installers
{
    public class ProviderManager : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly().BasedOn(typeof(IManageDataProviders)).WithServiceAllInterfaces());
        }
    }
}