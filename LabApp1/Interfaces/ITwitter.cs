using System.Collections.Generic;
using TwitterApi.Interfaces;
using TwitterApi;

namespace LabApp1.Interfaces
{
    public interface ITwitter
    {
        IAsyncEnumerable<Models.Statistics> AnalyzeTwitterStream(Authentication authentication, ISampledStream sampledStream, Models.Statistics statistics);
        void ProcessTweet(Models.TwitterApi.Tweet tweet, List<Models.Shared.Emoji> emojis, Models.Statistics statistics);
    }
}
