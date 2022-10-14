using System.Text.Json.Serialization;

namespace Models
{
    public partial class TwitterApi
    {
        public class Data
        {
            [JsonPropertyName("id")]
            public string Id { get; set; }
            
            [JsonPropertyName("text")]
            public string Text { get; set; }
        }
    }
}
