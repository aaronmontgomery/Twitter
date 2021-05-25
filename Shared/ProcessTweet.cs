using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shared
{
    public class Twitter
    {
        public async Task ProcessTweetAsync(Models.TwitterApi.Tweet tweet, IReadOnlyCollection<Models.Shared.Emoji> emojis, Models.Statistics statistics)
        {
            char[] chars = tweet.Data.Text.ToCharArray();

            if (tweet.Data.Text.Contains('#'))
            {
                //await GetHashTagsAsync(tweet, statistics);
            }

            if (tweet.Data.Text.ContainsUrl())
            {
                statistics.NumberOfTweetsThatContainUrl++;
            }

            // emojis
            if (false)
            {

            }

            statistics.TotalNumberOfTweetsReceived++;
        }
    }
}
