using System.IO;
using System.Collections.Generic;
using System.Net.Http;

namespace TwitterApi
{
    public class SampledStream //: Shared.WebClient
    {
        public async IAsyncEnumerable<Models.TwitterApi.Tweet> GetSampledStreamAsync(Models.TwitterApi.Token token)
        {
            using HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Authorization = System.Net.Http.Headers.AuthenticationHeaderValue.Parse($"Bearer {token.AccessToken}");

            using Stream stream = await httpClient.GetStreamAsync("https://api.twitter.com/2/tweets/sample/stream");

            using TextReader textReader = new StreamReader(stream);

            while (stream.CanRead)
            {
                string json;
                Models.TwitterApi.Tweet tweet;

                try
                {
                    json = await textReader.ReadLineAsync();
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
