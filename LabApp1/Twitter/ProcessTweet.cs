using System.Linq;
using System.Collections.Generic;
using Shared;

namespace LabApp1
{
    public partial class Twitter : Interfaces.ITwitter
    {
        public void ProcessTweet(Models.TwitterApi.Tweet tweet, IEnumerable<Models.Shared.Emoji> emojis, Models.Statistics statistics)
        {
            IList<Models.Shared.Emoji> emoticons;
            IDictionary<string, ulong> hashtags;
            IDictionary<string, ulong> urls;

            emoticons = tweet.Data.Text.GetEmojis(emojis);
            hashtags = tweet.Data.Text.CountStringPatternsEndsWithSpace(new string[] { "#" });
            urls = tweet.Data.Text.CountStringPatternsEndsWithSpace(new string[] { @"http://", @"https://" });

            foreach (Models.Shared.Emoji emoji in emoticons)
            {
                Extensions.AddOrUpdateUniqueCollection(statistics.Emojis, emoji.Name, (ulong)emoticons.Count(x => x.Name == emoji.Name));
            }

            foreach (KeyValuePair<string, ulong> item in hashtags)
            {
                Extensions.AddOrUpdateUniqueCollection(statistics.HashTags, item.Key, item.Value);
            }

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
