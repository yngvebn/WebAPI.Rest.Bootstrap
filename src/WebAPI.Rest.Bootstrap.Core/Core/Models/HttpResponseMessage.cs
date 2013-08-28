using System.Net.Http;

namespace WebAPI.Rest.Bootstrap.Core.Models
{
    public class HttpResponseMessage<T>: HttpResponseMessage
        where T: BaseApiResponse
    {
        public HttpResponseMessage()
        {
            
        }
    }
}