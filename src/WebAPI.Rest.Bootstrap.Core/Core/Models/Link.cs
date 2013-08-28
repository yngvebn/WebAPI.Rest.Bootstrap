namespace WebAPI.Rest.Bootstrap.Core.Models
{
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