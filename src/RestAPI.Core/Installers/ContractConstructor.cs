using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using RestAPI.Core.RequestConstructors;

namespace RestAPI.Core.Installers
{
    public class ContractConstructor: IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly().BasedOn(typeof(IManageContractConstructors)).WithServiceAllInterfaces());
        }
    }
}