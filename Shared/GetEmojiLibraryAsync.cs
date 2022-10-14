using System.Text.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Shared
{
    public class Emojis
    {
        public static async Task<Models.Shared.Emoji[]> GetEmojiLibraryAsync()
        {
            HttpClient httpClient;
            string json;
            Models.Shared.Emoji[] emojies;

            try
            {
                using (httpClient = new HttpClient())
                {
                    json = await httpClient.GetStringAsync("https://raw.githubusercontent.com/iamcal/emoji-data/master/emoji.json");
                    emojies = JsonSerializer.Deserialize<Models.Shared.Emoji[]>(json);
                }
            }

            catch
            {
                throw;
            }
            
            return emojies;
        }
    }
}
