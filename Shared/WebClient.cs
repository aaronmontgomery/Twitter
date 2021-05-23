using System.Net.Http;

namespace Shared
{
    public interface IWebClientProperties
    {

    }
    
    public class WebClient : IWebClientProperties
    {
        protected internal HttpClient httpClient;

        public WebClient()
        {

        }
    }
}
