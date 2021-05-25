using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterApi;

namespace LabApp1
{
    class Program
    {

        static async Task Main(string[] args)
        {
            Console.WriteLine("LabApp1 - Aaron Montgomery");

            AnalyzeTwitterStream analyzeTwitterStream = new AnalyzeTwitterStream();

            await analyzeTwitterStream.Run();
        }
    }

    public class AnalyzeTwitterStream
    {
        public async Task Run()
        {
            IReadOnlyCollection<Models.Shared.Emoji> emojis = await Shared.Emoji.GetEmjoisAsync();

            Authentication authentication = new Authentication();
            await authentication.TokenAsync();

            SampledStream sampledStream = new SampledStream();

            Models.Statistics statistics = new Models.Statistics();

            Shared.Twitter twitter = new Shared.Twitter();

            await foreach (Models.TwitterApi.Tweet tweet in sampledStream.GetSampledStreamAsync(authentication.Token))
            {
                if (tweet != null)
                {
                    await twitter.ProcessTweetAsync(tweet, emojis, statistics);
                }
            }
        }
    }
}
