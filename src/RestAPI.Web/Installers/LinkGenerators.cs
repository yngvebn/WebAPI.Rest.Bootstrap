using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using RestAPI.Core.LinkProviders;

namespace RestAPI.Web.Installers
{
    public class LinkGenerators : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly().BasedOn<IGenerateLinksFor>().WithServiceBase());
        }
    }
}