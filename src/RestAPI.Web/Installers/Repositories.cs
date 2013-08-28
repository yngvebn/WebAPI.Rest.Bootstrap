using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using RestAPI.Data;

namespace RestAPI.Web.Installers
{
    public class Repositories : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IProductRepository>().ImplementedBy<ProductRepository>());
        }
    }
}