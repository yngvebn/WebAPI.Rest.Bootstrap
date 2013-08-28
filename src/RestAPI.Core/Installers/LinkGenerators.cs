using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using RestAPI.Core.LinkProviders;

namespace RestAPI.Core.Installers
{
    public class LinkGenerators : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IGenerateLinkTo>().ImplementedBy<GenerateLinkTo>());
        }
    }
}