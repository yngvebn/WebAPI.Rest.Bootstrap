using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using WebAPI.Rest.Bootstrap.Core.Commands;

namespace WebAPI.Rest.Bootstrap.Web.Installers
{
    public class CommandHandlers : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(AllTypes.FromThisAssembly().BasedOn(typeof(ICommandHandler<>))
                                   .WithService.AllInterfaces());
        }
    }
}