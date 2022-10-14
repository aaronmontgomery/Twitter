using System.Collections.Generic;

namespace TwitterApi
{
    public partial class Interfaces
    {
        public interface ISampledStream
        {
            IAsyncEnumerable<Models.TwitterApi.Tweet> GetSampledStreamAsync(Models.TwitterApi.Token token);
        }
    }
}
