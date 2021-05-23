using System;
using System.Web;
using System.Net.Http;
using System.Threading.Tasks;

namespace TwitterApi
{
    public abstract class ConsumerKeys
    {
        public readonly string ApiKey = "8FNLUlqJLfwwTHMkgWfxWDCvx";
        public readonly string ApiSecretKey = "UN5DTFLZEgb3LhDIKVTH78HLlFQvrmjfATszKKjzzl8RSYaBvR";
    }

    public abstract class Keys : ConsumerKeys
    {
        public readonly HttpClient HttpClient = new HttpClient();
        public string EncodedKey;
        public Models.TwitterApi.Token Token;

        public Keys()
        {
            string urlEncodedKey = $"{HttpUtility.UrlEncode(ApiKey)}{":"}{HttpUtility.UrlEncode(ApiSecretKey)}";
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(urlEncodedKey);
            EncodedKey = Convert.ToBase64String(bytes);
        }
    }

    public class Authentication : Keys
    {
        public async Task<Models.TwitterApi.Token> TokenAsync()
        {
            HttpClient.DefaultRequestHeaders.Authorization = System.Net.Http.Headers.AuthenticationHeaderValue.Parse($"Basic {EncodedKey}");

            HttpContent body = new StringContent("grant_type=client_credentials", System.Text.Encoding.UTF8, "application/x-www-form-urlencoded");

            HttpResponseMessage httpResponseMessage = await HttpClient.PostAsync("https://api.twitter.com/oauth2/token", body);

            string json = await httpResponseMessage.Content.ReadAsStringAsync();
            
            Token = System.Text.Json.JsonSerializer.Deserialize<Models.TwitterApi.Token>(json);

            return Token;
        }
        
        public async Task InvalidateTokenAsync()
        {
            HttpClient.DefaultRequestHeaders.Authorization = System.Net.Http.Headers.AuthenticationHeaderValue.Parse($"OAuth oauth_consumer_key={"\""}CLIENT_KEY{"\""}");

            HttpContent body = new StringContent($"access_token={Token.AccessToken}", System.Text.Encoding.UTF8, "application/x-www-form-urlencoded");

            HttpResponseMessage httpResponseMessage = await HttpClient.PostAsync("https://api.twitter.com/oauth2/invalidate_token", body);
        }
    }
}
