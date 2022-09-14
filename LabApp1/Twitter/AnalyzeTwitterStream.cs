using System.Collections.Generic;
using TwitterApi;
using TwitterApi.Interfaces;

namespace LabApp1
{
    public partial class Twitter : Interfaces.ITwitter
    {
        public async IAsyncEnumerable<Models.Statistics> AnalyzeTwitterStream(Authentication authentication, ISampledStream sampledStream, Models.Statistics statistics, List<Models.Shared.Emoji> emojis)
        {
            await foreach (Models.TwitterApi.Tweet tweet in sampledStream.GetSampledStreamAsync(authentication.Token))
            {
                if (tweet != null)
                {
                    try
                    {
                        ProcessTweet(tweet, emojis, statistics);
                    }

                    catch
                    {

                    }

                    yield return statistics;
                }
            }
        }
    }
}
