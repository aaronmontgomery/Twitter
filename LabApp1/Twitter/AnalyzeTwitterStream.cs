using System.Collections.Generic;
using TwitterApi;

namespace LabApp1
{
    public partial class Twitter
    {
        public async IAsyncEnumerable<Models.Statistics> AnalyzeTwitterStream()
        {
            List<Models.Shared.Emoji> emojis = await Shared.Emojis.GetEmojiLibraryAsync();

            Authentication authentication = new Authentication();
            await authentication.TokenAsync();

            SampledStream sampledStream = new SampledStream();

            Models.Statistics statistics = new Models.Statistics();

            Shared.Twitter twitter = new Shared.Twitter();

            await foreach (Models.TwitterApi.Tweet tweet in sampledStream.GetSampledStreamAsync(authentication.Token))
            {
                if (tweet != null)
                {
                    twitter.ProcessTweet(tweet, emojis, statistics);
                    yield return statistics;
                }
            }
        }
    }
}
