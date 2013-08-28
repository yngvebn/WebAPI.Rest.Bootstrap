using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using WebAPI.Rest.Bootstrap.Implementations.LinkProviders;
using WebAPI.Rest.Bootstrap.Interfaces.LinkProvider;

namespace WebAPI.Rest.Bootstrap.Castle.Installers
{
    public class LinkGenerators : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<ILinkGenerator>().ImplementedBy<Implementations.LinkProviders.LinkGenerator>());
        }
    }
}