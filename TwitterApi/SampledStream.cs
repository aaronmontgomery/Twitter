using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using System.Net.Http;
using System.Net.Http.Headers;

namespace TwitterApi
{
    public class SampledStream : Interfaces.ISampledStream
    {
        public async IAsyncEnumerable<Models.TwitterApi.Tweet> GetSampledStreamAsync(Models.TwitterApi.Token token)
        {
            HttpClient httpClient;
            Stream stream;
            TextReader textReader;
            string json;
            Models.TwitterApi.Tweet tweet;

            using (httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse($"Bearer {token.AccessToken}");
                using (stream = await httpClient.GetStreamAsync("https://api.twitter.com/2/tweets/sample/stream"))
                {
                    using (textReader = new StreamReader(stream))
                    {
                        while (stream.CanRead)
                        {
                            try
                            {
                                json = await textReader.ReadLineAsync();
                                tweet = JsonSerializer.Deserialize<Models.TwitterApi.Tweet>(json);
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
        }
    }
}
