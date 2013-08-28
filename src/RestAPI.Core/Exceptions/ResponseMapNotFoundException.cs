using System;

namespace RestAPI.Core.Exceptions
{
    public class ResponseMapNotFoundException : Exception
    {
        public ResponseMapNotFoundException(string message, Type expectedType)
            :base(string.Format("{0}\n\nPlease setup a map that has {1} as destination-type and a Contract as source-type", message, expectedType))

        {
        }
    }
}