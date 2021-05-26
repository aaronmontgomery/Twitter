﻿using System;
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
                Console.SetCursorPosition(0, 1);
                Console.WriteLine("TotalNumberOfTweetsReceived: " + statistics.TotalNumberOfTweetsReceived);
                Console.WriteLine("AverageTweetsPerHour: " + statistics.AverageTweetsPerHour);
                Console.WriteLine("AverageTweetsPerMinute: " + statistics.AverageTweetsPerMinute);
                Console.WriteLine("AverageTweetsPerSecond: " + statistics.AverageTweetsPerSecond);
            }
        }
    }
}
