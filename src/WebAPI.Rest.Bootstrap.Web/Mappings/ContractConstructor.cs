using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using WebAPI.Rest.Bootstrap.Interfaces.ContractConstructor;

namespace WebAPI.Rest.Bootstrap.Web.Mappings
{
    public class ContractConstructor: IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly().BasedOn(typeof(IConstructContractFrom<>)).WithServiceAllInterfaces());
        }
    }
}