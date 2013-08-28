using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using RestAPI.Core.DataProviders;

namespace RestAPI.Core.Installers
{
    public class ProviderManager : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly().BasedOn(typeof(IManageDataProviders)).WithServiceAllInterfaces());
        }
    }
}