using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using RestAPI.Core.Mapping;

namespace RestAPI.Web.Installers
{

        public class Mappings : IWindsorInstaller
        {
            public void Install(IWindsorContainer container, IConfigurationStore store)
            {
                container.Register(Classes.FromThisAssembly().BasedOn<IMappingConfiguration>().WithService.AllInterfaces());
            }
        }

}