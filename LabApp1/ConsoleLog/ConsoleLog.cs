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
            Console.OutputEncoding = Encoding.UTF8;
            Console.Clear();
            Console.SetCursorPosition(0, 1);
            Console.WriteLine("LabApp1 - Aaron Montgomery");
            Console.SetCursorPosition(0, 3);
            Console.WriteLine("TotalNumberOfTweetsReceived: " + statistics.TotalNumberOfTweetsReceived, 0, Console.BufferWidth);
            Console.SetCursorPosition(0, 4);
            Console.WriteLine("AverageTweetsPerHour: " + statistics.AverageTweetsPerHour, 0, Console.BufferWidth);
            Console.SetCursorPosition(0, 5);
            Console.WriteLine("AverageTweetsPerMinute: " + statistics.AverageTweetsPerMinute, 0, Console.BufferWidth);
            Console.SetCursorPosition(0, 6);
            Console.WriteLine("AverageTweetsPerSecond: " + statistics.AverageTweetsPerSecond, 0, Console.BufferWidth);
            Console.SetCursorPosition(0, 7);
            Console.WriteLine("TopEmojis: " + statistics.Emojis.OrderByDescending(x => x.Value).FirstOrDefault(), 0, Console.BufferWidth);
            Console.SetCursorPosition(0, 8);
            Console.WriteLine("PercentOfTweetsThatContainEmojis: " + statistics.PercentOfTweetsThatContainEmojis, 0, Console.BufferWidth);
            Console.SetCursorPosition(0, 9);
            Console.WriteLine("TopHashTags: " + statistics.HashTags.OrderByDescending(x => x.Value).FirstOrDefault(), 0, Console.BufferWidth);
            Console.SetCursorPosition(0, 10);
            Console.WriteLine("PercentOfTweetsThatContainUrl: " + statistics.PercentOfTweetsThatContainUrl, 0, Console.BufferWidth);
            Console.SetCursorPosition(0, 11);
            Console.WriteLine("PercentOfTweetsThatContainPhotoUrl: " + statistics.PercentOfTweetsThatContainPhotoUrl, 0, Console.BufferWidth);
            Console.SetCursorPosition(0, 12);
            Console.WriteLine("TopDomainsOfUrlsInTweets: " + statistics.Urls.OrderByDescending(x => x.Value).FirstOrDefault(), 0, Console.BufferWidth);
            Thread.Sleep(100);
        }
    }
}
