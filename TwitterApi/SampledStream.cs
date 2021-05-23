using System.Collections.Generic;
using System.IO;
using System.Net.Http;

namespace TwitterApi
{
    public class SampledStream
    {
        public async IAsyncEnumerable<Models.TwitterApi.Tweet> GetSampledStreamAsync(Models.TwitterApi.Token token)
        {
            using HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = System.Net.Http.Headers.AuthenticationHeaderValue.Parse($"Bearer {token.AccessToken}");
            using Stream stream = await httpClient.GetStreamAsync("https://api.twitter.com/2/tweets/sample/stream");
            TextReader streamReader = new StreamReader(stream);
            
            while (stream.CanRead)
            {
                Models.TwitterApi.Tweet tweet;

                try
                {
                    string json = await streamReader.ReadLineAsync();
                    tweet = System.Text.Json.JsonSerializer.Deserialize<Models.TwitterApi.Tweet>(json);
                }

                catch
                {
                    tweet = null;
                }

                yield return tweet;
            }
        }
    }
}
