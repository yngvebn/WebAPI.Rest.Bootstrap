using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using WebAPI.Rest.Bootstrap.Interfaces.ContractConstructor;

namespace WebAPI.Rest.Bootstrap.Castle.Installers
{
    public class ContractConstructor: IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly().BasedOn<IManageContractConstructors>().WithServiceAllInterfaces());
            container.Register(Classes.FromThisAssembly().BasedOn<IConstructContractFrom>().WithServiceAllInterfaces());
        }
    }
}