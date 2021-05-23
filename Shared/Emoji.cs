using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shared
{
    public class Emoji
    {
        public static async Task<IEnumerable<Models.Shared.Emoji>> GetEmjois()
        {
            using System.Net.Http.HttpClient httpClient = new System.Net.Http.HttpClient();
            string json = await httpClient.GetStringAsync("https://raw.githubusercontent.com/iamcal/emoji-data/master/emoji.json");
            IEnumerable<Models.Shared.Emoji> emojies = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<Models.Shared.Emoji>>(json);
            return emojies;
        }
    }
}
