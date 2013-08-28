using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using WebAPI.Rest.Bootstrap.Interfaces.Mapping;

namespace WebAPI.Rest.Bootstrap.Castle.Installers
{

        public class Mappings : IWindsorInstaller
        {
            public void Install(IWindsorContainer container, IConfigurationStore store)
            {
                container.Register(Classes.FromThisAssembly().BasedOn<IMapper>().WithService.AllInterfaces());
            }
        }

}