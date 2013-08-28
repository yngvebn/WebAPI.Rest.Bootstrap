using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using WebAPI.Rest.Bootstrap.Data;

namespace WebAPI.Rest.Bootstrap.Web.Installers
{
    public class Repositories : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IProductRepository>().ImplementedBy<ProductRepository>());
        }
    }
}