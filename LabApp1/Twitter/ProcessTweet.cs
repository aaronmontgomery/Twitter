using Shared;
using System.Linq;
using System.Collections.Generic;

namespace LabApp1
{
    public partial class Twitter
    {
        public void ProcessTweet(Models.TwitterApi.Tweet tweet, List<Models.Shared.Emoji> emojis, Models.Statistics statistics)
        {
            List<Models.Shared.Emoji> emoticons = tweet.Data.Text.GetEmojis(emojis);

            foreach (Models.Shared.Emoji emoji in emoticons)
            {
                Extensions.AddOrUpdateUniqueCollection(statistics.Emojis, emoji.Name, (ulong)emoticons.Count(x => x.Name == emoji.Name));
            }

            Dictionary<string, ulong> hashtags = tweet.Data.Text.CountStringPatternsEndsWithSpace(new string[] { "#" });

            foreach (KeyValuePair<string, ulong> item in hashtags)
            {
                Extensions.AddOrUpdateUniqueCollection(statistics.HashTags, item.Key, item.Value);
            }

            Dictionary<string, ulong> urls = tweet.Data.Text.CountStringPatternsEndsWithSpace(new string[] { @"http://", @"https://" });

            foreach (KeyValuePair<string, ulong> item in urls)
            {
                Extensions.AddOrUpdateUniqueCollection(statistics.Urls, item.Key, item.Value);
            }

            if (emoticons.Count > 0)
            {
                statistics.NumberOfTweetsThatContainEmojis++;
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
