using System.Collections.Generic;

namespace Shared
{
    public class Twitter
    {
        public void ProcessTweet(Models.TwitterApi.Tweet tweet, IReadOnlyCollection<Models.Shared.Emoji> emojis, Models.Statistics statistics)
        {
            IReadOnlyDictionary<string, ulong> hashtags = tweet.Data.Text.CountStringPatternsEndsWithSpace(new string[] { "#" });

            foreach (KeyValuePair<string, ulong> item in hashtags)
            {
                Extentions.AddOrUpdateUniqueCollection(statistics.HashTags, item.Key, item.Value);
            }

            IReadOnlyDictionary<string, ulong> urls = tweet.Data.Text.CountStringPatternsEndsWithSpace(new string[] { @"http://", @"https://" });

            foreach (KeyValuePair<string, ulong> item in urls)
            {
                Extentions.AddOrUpdateUniqueCollection(statistics.Urls, item.Key, item.Value);
            }

            if (tweet.Data.Text.ContainsUrl())
            {
                statistics.NumberOfTweetsThatContainUrl++;
            }

            statistics.TotalNumberOfTweetsReceived++;
        }
    }
}
