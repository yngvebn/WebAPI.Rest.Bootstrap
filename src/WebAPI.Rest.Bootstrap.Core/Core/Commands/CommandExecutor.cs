using System;
using Castle.Windsor;

namespace WebAPI.Rest.Bootstrap.Core.Commands
{
    public class CommandExecutor : ICommandExecutor
    {
        private readonly IWindsorContainer _kernel;

        public CommandExecutor(IWindsorContainer kernel)
        {
            _kernel = kernel;
        }

        public CommandResult ExecuteCommand(object command)
        {
            dynamic handler = FindHandlerForCommand(command);

            try
            {
                var data = handler.Handle(command as dynamic);
                return CommandResult.Executed("Command executed successfully", data);
            }
            catch (Exception ex)
            {
                return CommandResult.Failed(ex.Message);
            }
            finally
            {
                _kernel.Release(handler);
            }
        }

        private object FindHandlerForCommand(object command)
        {
            var handlerType = typeof(ICommandHandler<>).MakeGenericType(command.GetType());
            dynamic handler = _kernel.Resolve(handlerType);
            return handler;
        }
    }
}