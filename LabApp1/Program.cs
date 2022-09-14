using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LabApp1.Interfaces;
using TwitterApi;
using TwitterApi.Interfaces;
using Shared;

namespace LabApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IConsoleLog consoleLog;
            ITwitter twitter;
            Authentication authentication;
            ISampledStream sampledStream;
            Models.Statistics statistics;
            List<Models.Shared.Emoji> emojis;

            consoleLog = new ConsoleLog();
            twitter = new Twitter();
            authentication = new Authentication();
            sampledStream = new SampledStream();
            statistics = new Models.Statistics();
            emojis = null;

            try
            {
                authentication.Token = await authentication.GetTokenAsync();
                emojis = await Emojis.GetEmojiLibraryAsync();
            }

            catch
            {
                Console.WriteLine("Unable to start");
            }
            
            if (authentication.Token != null && emojis != null)
            {
                await foreach (Models.Statistics statistic in twitter.AnalyzeTwitterStream(authentication, sampledStream, statistics, emojis))
                {
                    try
                    {
                        consoleLog.LogToConsole(statistic);
                    }

                    catch
                    {

                    }
                }
            }
        }
    }
}
