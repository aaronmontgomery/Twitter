using System.Text;
using System.Text.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace TwitterApi
{
    public partial class Authentication : Key, Interfaces.IAuthentication
    {
        public async Task<Models.TwitterApi.Token> GetTokenAsync()
        {
            HttpClient httpClient;
            HttpContent httpContent;
            HttpResponseMessage httpResponseMessage;
            string json;

            try
            {
                using (httpClient = new())
                {
                    httpClient.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse($"Basic {EncodedKey}");
                    httpContent = new StringContent("grant_type=client_credentials", Encoding.UTF8, "application/x-www-form-urlencoded");
                    httpResponseMessage = await httpClient.PostAsync("https://api.twitter.com/oauth2/token", httpContent);
                    json = await httpResponseMessage.Content.ReadAsStringAsync();
                    Token = JsonSerializer.Deserialize<Models.TwitterApi.Token>(json);
                }
            }

            catch
            {
                throw;
            }
            
            return Token;
        }
    }
}
