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
            Console.WriteLine($"Total Number Of Tweets Received: {statistics.TotalNumberOfTweetsReceived}", 0, Console.BufferWidth);
            Console.SetCursorPosition(0, ++count);
            Console.WriteLine($"Average Tweets/Hour: {statistics.AverageTweetsPerHour}", 0, Console.BufferWidth);
            Console.SetCursorPosition(0, ++count);
            Console.WriteLine($"Average Tweets/Minute: {statistics.AverageTweetsPerMinute}", 0, Console.BufferWidth);
            Console.SetCursorPosition(0, ++count);
            Console.WriteLine($"Average Tweets/Second: {statistics.AverageTweetsPerSecond}", 0, Console.BufferWidth);

            foreach (var emoji in statistics.Emojis.OrderByDescending(x => x.Value).Take(10))
            {
                Console.SetCursorPosition(0, ++count);
                Console.WriteLine($"Top Emojis {count - 6}: " + emoji, 0, Console.BufferWidth);
            }
            
            Console.SetCursorPosition(0, ++count);
            Console.WriteLine($"Percent Of Tweets That Contain Emojis: {statistics.PercentOfTweetsThatContainEmojis}%", 0, Console.BufferWidth);
            Console.SetCursorPosition(0, ++count);
            Console.WriteLine($"Top Hash Tags: {statistics.HashTags.OrderByDescending(x => x.Value).FirstOrDefault()}", 0, Console.BufferWidth);
            Console.SetCursorPosition(0, ++count);
            Console.WriteLine($"Percent Of Tweets That Contain Url: {statistics.PercentOfTweetsThatContainUrl}%", 0, Console.BufferWidth);
            Console.SetCursorPosition(0, ++count);
            Console.WriteLine($"Percent Of Tweets That Contain Photo Url: {statistics.PercentOfTweetsThatContainPhotoUrl}%", 0, Console.BufferWidth);
            Console.SetCursorPosition(0, ++count);
            Console.WriteLine($"Top Domains Of Urls In Tweets: {statistics.Urls.OrderByDescending(x => x.Value).FirstOrDefault()}", 0, Console.BufferWidth);

            Thread.Sleep(100);
        }
    }
}
