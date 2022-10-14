using System.Text.Json.Serialization;

namespace Models
{
    public partial class TwitterApi
    {
        public class Tweet
        {
            [JsonPropertyName("data")]
            public Data Data { get; set; }
        }
    }
}
