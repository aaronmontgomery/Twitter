using System.Collections.Generic;
using TwitterApi;

namespace LabApp1
{
    public partial class Interfaces
    {
        internal interface ITwitter
        {
            IAsyncEnumerable<Models.Statistics> AnalyzeTwitterStream(Authentication authentication, TwitterApi.Interfaces.ISampledStream sampledStream, Models.Statistics statistics, IEnumerable<Models.Shared.Emoji> emojis);
            void ProcessTweet(Models.TwitterApi.Tweet tweet, IEnumerable<Models.Shared.Emoji> emojis, Models.Statistics statistics);
        }
    }
}
