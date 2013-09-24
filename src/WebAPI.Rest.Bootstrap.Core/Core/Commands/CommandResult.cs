namespace WebAPI.Rest.Bootstrap.Core.Commands
{
    public class CommandResult
    {
        public static CommandResult Executed(string message, object data)
        {
            return new CommandResult { Status = CommandStatus.Executed, Message = message, Data = data };
        }

        public static CommandResult Failed(string message)
        {
            return new CommandResult { Status = CommandStatus.Failed, Message = message };
        }

        public bool IsExecuted
        {
            get { return Status == CommandStatus.Executed; }
        }

        public string Message { get; set; }

        public object Data { get; set; }

        public CommandStatus Status { get; set; }

        public CommandErrorCode ErrorCode { get; set; }
    }
}