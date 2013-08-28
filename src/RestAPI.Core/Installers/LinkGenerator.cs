using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using RestAPI.Core.LinkProviders;

namespace RestAPI.Core.Installers
{
    public class LinkGenerator : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly().BasedOn(typeof(IManageLinkProviders)).WithServiceAllInterfaces());
            container.Register(Classes.FromThisAssembly().BasedOn<IGenerateLinksFor>().WithService.AllInterfaces());
        }
    }
}