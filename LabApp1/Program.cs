using System.Threading.Tasks;
using LabApp1.Interfaces;
using TwitterApi.Interfaces;
using TwitterApi;

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

            consoleLog = new ConsoleLog();
            twitter = new Twitter();
            authentication = new Authentication();
            sampledStream = new SampledStream();
            statistics = new Models.Statistics();

            await foreach (Models.Statistics statistic in twitter.AnalyzeTwitterStream(authentication, sampledStream, statistics))
            {
                consoleLog.LogToConsole(statistic);
            }
        }
    }
}
