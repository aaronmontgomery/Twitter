using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shared
{
    public class Emojis
    {
        public static async Task<IReadOnlyCollection<Models.Shared.Emoji>> GetEmjoisAsync()
        {
            using System.Net.Http.HttpClient httpClient = new System.Net.Http.HttpClient();
            string json = await httpClient.GetStringAsync("https://raw.githubusercontent.com/iamcal/emoji-data/master/emoji.json");
            IReadOnlyCollection<Models.Shared.Emoji> emojies = System.Text.Json.JsonSerializer.Deserialize<IReadOnlyCollection<Models.Shared.Emoji>>(json);
            return emojies;
        }
    }
}
