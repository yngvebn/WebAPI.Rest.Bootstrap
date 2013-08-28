using System.Net.Http;

namespace RestAPI.Core.Models
{
    public class HttpResponseMessage<T>: HttpResponseMessage
        where T: BaseApiResponse
    {
        public HttpResponseMessage()
        {
            
        }
    }

    public class Link
    {
        public Link(string name, string url)
        {
            Name = name;
            Url = url;
        }

        public string Name { get; set; }
        public string Url { get; set; }
    }
}