using System.Linq;
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
                await GetHashTagsAsync(tweet, statistics);
            }

            // http*:
            string[] urlPrefixes = new string[] { @"http://", @"https://" };
            if (tweet.Data.Text.Contains(urlPrefixes[0]) || tweet.Data.Text.Contains(urlPrefixes[1]))
            {

            }

            // emojis
            if (false)
            {

            }

            statistics.TotalNumberOfTweetReceived++;
        }

        public async Task GetHashTagsAsync(Models.TwitterApi.Tweet tweet, Models.Statistics statistics)
        {

        }
    }
}
