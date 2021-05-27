using System.Collections.Generic;

namespace Shared
{
    public class Twitter
    {
        public void ProcessTweet(Models.TwitterApi.Tweet tweet, IReadOnlyCollection<Models.Shared.Emoji> emojis, Models.Statistics statistics)
        {
            IReadOnlyDictionary<string, ulong> emoticons = tweet.Data.Text.GetEmojis(emojis);

            foreach (KeyValuePair<string, ulong> item in emoticons)
            {
                Extensions.AddOrUpdateUniqueCollection(statistics.Emojis, item.Key, item.Value);
            }

            IReadOnlyDictionary<string, ulong> hashtags = tweet.Data.Text.CountStringPatternsEndsWithSpace(new string[] { "#" });

            foreach (KeyValuePair<string, ulong> item in hashtags)
            {
                Extensions.AddOrUpdateUniqueCollection(statistics.HashTags, item.Key, item.Value);
            }

            IReadOnlyDictionary<string, ulong> urls = tweet.Data.Text.CountStringPatternsEndsWithSpace(new string[] { @"http://", @"https://" });

            foreach (KeyValuePair<string, ulong> item in urls)
            {
                Extensions.AddOrUpdateUniqueCollection(statistics.Urls, item.Key, item.Value);
            }

            if (tweet.Data.Text.ContainsEmoji(emojis))
            {

            }

            if (tweet.Data.Text.ContainsUrl())
            {
                statistics.NumberOfTweetsThatContainUrl++;
            }

            if (tweet.Data.Text.Contains("pic.twitter.com") || tweet.Data.Text.Contains("Instagram"))
            {
                statistics.NumberOfTweetsThatContainPhotoUrl++;
            }

            statistics.TotalNumberOfTweetsReceived++;
        }
    }
}
