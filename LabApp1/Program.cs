using System;
using System.Threading.Tasks;
using TwitterApi;

namespace LabApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("LabApp1 - Aaron Montgomery");

            Authentication authentication = new Authentication();
            await authentication.TokenAsync();

            SampledStream sampledStream = new SampledStream();
            await foreach (Models.TwitterApi.Tweet tweet in sampledStream.GetSampledStreamAsync(authentication.Token))
            {
                if (tweet != null)
                {
                    // process tweet
                    char[] chars = tweet.Data.Text.ToCharArray();
                    Console.WriteLine("id: " + tweet.Data.Id);
                    Console.WriteLine("text: " + tweet.Data.Text);
                    Console.WriteLine("------------------------------------------------------------------------------------");
                    //Console.ReadKey();
                    await Task.Delay(1000);
                }
            }

            /*
            

            char[] x = chars.Where(x => x.ToString().StartsWith("\\u")).Select(x => x).ToArray();

            // #
            if (tweet.Data.Text.Contains('#'))
            {

            }

            // http*:
            string[] urlPrefixes = new string[] { @"http://", @"https://" };
            if (tweet.Data.Text.Contains(urlPrefixes[0]) || tweet.Data.Text.Contains(urlPrefixes[1]))
            {

            }

            // emojis
            if (false)
            {

            }

            if (x.Count() > 0)
            {

            }
            */
        }
    }
}
