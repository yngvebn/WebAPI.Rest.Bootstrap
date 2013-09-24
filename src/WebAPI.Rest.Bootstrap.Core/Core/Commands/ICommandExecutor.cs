namespace WebAPI.Rest.Bootstrap.Core.Commands
{
    public interface ICommandExecutor
    {
        CommandResult ExecuteCommand(object command);
    }
}