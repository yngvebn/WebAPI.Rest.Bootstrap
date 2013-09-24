using System;
using WebAPI.Rest.Bootstrap.Contracts;
using WebAPI.Rest.Bootstrap.Core.Commands;

namespace WebAPI.Rest.Bootstrap.Web.Commands.Handlers
{
    public class HandleUpdateProductCommand: ICommandHandler<UpdateProductCommand>
    {
        public HandleUpdateProductCommand()
        {
            
        }


        public object Handle(UpdateProductCommand command)
        {
            throw new InvalidOperationException("Whatever");
            return new Product()
                {
                    Sku = 1,
                    Manufacturer = "Leap"
                };
        }
    }
}