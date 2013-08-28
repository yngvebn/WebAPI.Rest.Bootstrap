using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using WebAPI.Rest.Bootstrap.Interfaces.LinkProvider;

namespace WebAPI.Rest.Bootstrap.Castle.Installers
{
    public class LinkGenerator : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly().BasedOn(typeof(IPopulateLinksForModel)).WithServiceAllInterfaces());
            container.Register(Classes.FromThisAssembly().BasedOn<IGenerateLinksFor>().WithService.AllInterfaces());
        }
    }
}