namespace WebAPI.Rest.Bootstrap.Core.Commands
{
    public interface ICommandHandler<in T>
    {
        System.Object Handle(T command);
    }
}