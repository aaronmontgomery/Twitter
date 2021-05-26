using System;
using System.Linq;
using System.Threading.Tasks;

namespace LabApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            ConsoleLog consoleLog = new ConsoleLog();

            Twitter twitter = new Twitter();

            await foreach (Models.Statistics statistics in twitter.AnalyzeTwitterStream())
            {
                consoleLog.LogToConsole(statistics);
            }
        }

        public class ConsoleLog
        {
            public ConsoleLog()
            {
                Console.WriteLine("LabApp1 - Aaron Montgomery");
            }

            public void LogToConsole(Models.Statistics statistics)
            {
                Console.SetCursorPosition(0, 2);
                Console.WriteLine("TotalNumberOfTweetsReceived: " + statistics.TotalNumberOfTweetsReceived);
                Console.WriteLine("AverageTweetsPerHour: " + statistics.AverageTweetsPerHour);
                Console.WriteLine("AverageTweetsPerMinute: " + statistics.AverageTweetsPerMinute);
                Console.WriteLine("AverageTweetsPerSecond: " + statistics.AverageTweetsPerSecond);
                Console.WriteLine("TopEmojis: ");
                Console.WriteLine("PercentOfTweetsThatContainEmojis: ");
                Console.WriteLine("TopHashTags: " + statistics.HashTags.FirstOrDefault());
                Console.WriteLine("PercentOfTweetsThatContainUrl: " + statistics.PercentOfTweetsThatContainUrl);
                Console.WriteLine("PercentOfTweetsThatContainPhotoUrl: " + statistics.PercentOfTweetsThatContainPhotoUrl);
                Console.WriteLine("TopDomainsOfUrlsInTweets: " + statistics.Urls.FirstOrDefault());
            }
        }
    }
}
