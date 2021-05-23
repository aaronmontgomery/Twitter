using System.Net.Http;
using System.Threading.Tasks;

namespace TwitterApi
{
    public class Authentication : Key
    {
        public async Task<Models.TwitterApi.Token> TokenAsync()
        {
            using HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Authorization = System.Net.Http.Headers.AuthenticationHeaderValue.Parse($"Basic {EncodedKey}");

            HttpContent body = new StringContent("grant_type=client_credentials", System.Text.Encoding.UTF8, "application/x-www-form-urlencoded");

            HttpResponseMessage httpResponseMessage = await httpClient.PostAsync("https://api.twitter.com/oauth2/token", body);

            string json = await httpResponseMessage.Content.ReadAsStringAsync();
            
            Token = System.Text.Json.JsonSerializer.Deserialize<Models.TwitterApi.Token>(json);

            return Token;
        }
        
        public async Task InvalidateTokenAsync()
        {
            using HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Authorization = System.Net.Http.Headers.AuthenticationHeaderValue.Parse($"OAuth oauth_consumer_key={"\""}CLIENT_KEY{"\""}");

            HttpContent body = new StringContent($"access_token={Token.AccessToken}", System.Text.Encoding.UTF8, "application/x-www-form-urlencoded");

            HttpResponseMessage httpResponseMessage = await httpClient.PostAsync("https://api.twitter.com/oauth2/invalidate_token", body);
        }
    }
}
