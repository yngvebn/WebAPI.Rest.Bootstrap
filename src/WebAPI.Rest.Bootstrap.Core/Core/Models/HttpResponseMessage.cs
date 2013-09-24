using System.Net.Http;

namespace WebAPI.Rest.Bootstrap.Core.Models
{
    public class HttpResourceMessage<T>: HttpResponseMessage<T>
        where T: BaseApiResponse{}

    public class HttpResponseMessage<T>: HttpResponseMessage
        where T: BaseApiResponse
    {
        public HttpResponseMessage()
        {
            
        }
    }
}