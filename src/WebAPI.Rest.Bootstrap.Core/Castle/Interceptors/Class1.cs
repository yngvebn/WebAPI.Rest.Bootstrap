using System;
using Castle.DynamicProxy;
using WebAPI.Rest.Bootstrap.Core.Commands;

namespace WebAPI.Rest.Bootstrap.Castle.Interceptors
{
   
    public class ExceptionToCommandResult : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            try
            {
                invocation.Proceed();
            }
            catch (Exception ex)
            {
                ex = Unwrap(ex);

                var result = new CommandResult { Status = CommandStatus.Failed, Message = ex.Message, ErrorCode = GetErrorCodeFromExceptionType(ex) };
                invocation.ReturnValue = result;
            }
        }

        private CommandErrorCode GetErrorCodeFromExceptionType(Exception exception)
        {
            return CommandErrorCode.Unknown;
        }

        private static Exception Unwrap(Exception ex)
        {
            while (null != ex.InnerException)
            {
                ex = ex.InnerException;
            }

            return ex;
        }
    }
}