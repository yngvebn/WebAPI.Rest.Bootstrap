using Castle.DynamicProxy;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using WebAPI.Rest.Bootstrap.Core.Commands;

namespace WebAPI.Rest.Bootstrap.Castle.Installers
{
    public class CommandsInstaller: IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(AllTypes.FromAssemblyContaining<CommandExecutor>().BasedOn<IInterceptor>().WithService.Self());

            container.Register(Component.For<ICommandExecutor>().ImplementedBy<CommandExecutor>());
            //.Interceptors<ContainerScopeWrapper>()
            //.Interceptors<TransactionWrapper>()
            //.Interceptors<SameNhibernateSessionAndTransactionWrapper>());
        }

    }
}