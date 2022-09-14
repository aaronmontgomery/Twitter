using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TwitterApi
{
    public partial class Authentication : Key
    {
        public async Task InvalidateTokenAsync()
        {
            HttpClient httpClient;
            HttpContent httpContent;
            HttpResponseMessage httpResponseMessage;
            
            using (httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse($"OAuth oauth_consumer_key={"\""}CLIENT_KEY{"\""}");
                httpContent = new StringContent($"access_token={Token.AccessToken}", Encoding.UTF8, "application/x-www-form-urlencoded");
                httpResponseMessage = await httpClient.PostAsync("https://api.twitter.com/oauth2/invalidate_token", httpContent);
            }
        }
    }
}
