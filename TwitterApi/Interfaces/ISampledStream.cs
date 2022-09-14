using System.Collections.Generic;

namespace TwitterApi.Interfaces
{
    public interface ISampledStream
    {
        IAsyncEnumerable<Models.TwitterApi.Tweet> GetSampledStreamAsync(Models.TwitterApi.Token token);
    }
}
