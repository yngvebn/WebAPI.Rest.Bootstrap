using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using WebAPI.Rest.Bootstrap.Interfaces.LinkProvider;

namespace WebAPI.Rest.Bootstrap.Web.Installers
{
    public class LinkGenerators : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly().BasedOn<IGenerateLinksFor>().WithServiceBase());
        }
    }
}