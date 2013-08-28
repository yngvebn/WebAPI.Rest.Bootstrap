using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using RestAPI.Core.RequestConstructors;

namespace RestAPI.Web.Mappings
{
    public class ContractConstructor: IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly().BasedOn(typeof(IConstructContractFrom<>)).WithServiceAllInterfaces());
        }
    }
}