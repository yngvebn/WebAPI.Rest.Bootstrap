namespace WebAPI.Rest.Bootstrap.Core.Commands
{
    public interface ICommandHandler<in T>
    {
        object Handle(T command);
    }
}