using System.Text.Json.Serialization;

namespace Models
{
    public partial class Shared
    {
        public class Emoji
        {
            [JsonPropertyName("unified")]
            public string Unified { get; set; }
            
            [JsonPropertyName("name")]
            public string Name { get; set; }
            
            [JsonPropertyName("image")]
            public string Image { get; set; }

            public char[] Unicode { get; set; }
        }
    }
}
