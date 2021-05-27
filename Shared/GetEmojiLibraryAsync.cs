using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shared
{
    public class Emojis
    {
        public static async Task<List<Models.Shared.Emoji>> GetEmojiLibraryAsync()
        {
            using System.Net.Http.HttpClient httpClient = new System.Net.Http.HttpClient();
            string json = await httpClient.GetStringAsync("https://raw.githubusercontent.com/iamcal/emoji-data/master/emoji.json");
            List<Models.Shared.Emoji> emojies = System.Text.Json.JsonSerializer.Deserialize<List<Models.Shared.Emoji>>(json);
            return emojies;
        }
    }
}
