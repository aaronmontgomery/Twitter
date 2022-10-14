using System;
using System.Threading.Tasks;
using TwitterApi;
using Shared;
using static TwitterApi.Interfaces;

namespace LabApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Interfaces.IConsoleLog consoleLog;
            Interfaces.ITwitter twitter;
            Authentication authentication;
            ISampledStream sampledStream;
            Models.Statistics statistics;
            Models.Shared.Emoji[] emojis;

            consoleLog = new ConsoleLog();
            twitter = new Twitter();
            authentication = new Authentication();
            sampledStream = new SampledStream();
            statistics = new Models.Statistics();
            
            try
            {
                authentication.Token = await authentication.GetTokenAsync();
                emojis = await Emojis.GetEmojiLibraryAsync();
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

            catch
            {
                Console.WriteLine("Unable to start");
            }
        }
    }
}
