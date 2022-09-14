using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;

namespace Shared
{
    public class Emojis
    {
        public static async Task<List<Models.Shared.Emoji>> GetEmojiLibraryAsync()
        {
            HttpClient httpClient;
            string json;
            List<Models.Shared.Emoji> emojies;
            
            using (httpClient = new HttpClient())
            {
                json = await httpClient.GetStringAsync("https://raw.githubusercontent.com/iamcal/emoji-data/master/emoji.json");
                emojies = JsonSerializer.Deserialize<List<Models.Shared.Emoji>>(json);
            }
            
            return emojies;
        }
    }
}
