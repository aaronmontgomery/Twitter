using System;
using System.Linq;
using System.Text;
using System.Threading;

namespace LabApp1
{
    public partial class ConsoleLog : Interfaces.IConsoleLog
    {
        public void LogToConsole(Models.Statistics statistics)
        {
            byte count;

            count = 0;
            Console.OutputEncoding = Encoding.UTF8;
            Console.Clear();

            Console.SetCursorPosition(0, ++count);
            Console.WriteLine("LabApp1 - Aaron Montgomery");
            Console.SetCursorPosition(0, count += 2);
            Console.WriteLine("TotalNumberOfTweetsReceived: " + statistics.TotalNumberOfTweetsReceived, 0, Console.BufferWidth);
            Console.SetCursorPosition(0, ++count);
            Console.WriteLine("AverageTweetsPerHour: " + statistics.AverageTweetsPerHour, 0, Console.BufferWidth);
            Console.SetCursorPosition(0, ++count);
            Console.WriteLine("AverageTweetsPerMinute: " + statistics.AverageTweetsPerMinute, 0, Console.BufferWidth);
            Console.SetCursorPosition(0, ++count);
            Console.WriteLine("AverageTweetsPerSecond: " + statistics.AverageTweetsPerSecond, 0, Console.BufferWidth);

            foreach (var emoji in statistics.Emojis.OrderByDescending(x => x.Value).Take(10))
            {
                Console.SetCursorPosition(0, ++count);
                Console.WriteLine("TopEmojis: " + emoji, 0, Console.BufferWidth);
            }
            
            Console.SetCursorPosition(0, ++count);
            Console.WriteLine("PercentOfTweetsThatContainEmojis: " + statistics.PercentOfTweetsThatContainEmojis, 0, Console.BufferWidth);
            Console.SetCursorPosition(0, ++count);
            Console.WriteLine("TopHashTags: " + statistics.HashTags.OrderByDescending(x => x.Value).FirstOrDefault(), 0, Console.BufferWidth);
            Console.SetCursorPosition(0, ++count);
            Console.WriteLine("PercentOfTweetsThatContainUrl: " + statistics.PercentOfTweetsThatContainUrl, 0, Console.BufferWidth);
            Console.SetCursorPosition(0, ++count);
            Console.WriteLine("PercentOfTweetsThatContainPhotoUrl: " + statistics.PercentOfTweetsThatContainPhotoUrl, 0, Console.BufferWidth);
            Console.SetCursorPosition(0, ++count);
            Console.WriteLine("TopDomainsOfUrlsInTweets: " + statistics.Urls.OrderByDescending(x => x.Value).FirstOrDefault(), 0, Console.BufferWidth);

            Thread.Sleep(100);
        }
    }
}
