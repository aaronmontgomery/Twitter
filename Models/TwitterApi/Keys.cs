using System.Text.Json.Serialization;

namespace Models
{
    public partial class TwitterApi
    {
        public class Keys
        {
            [JsonPropertyName("name")]
            public string Name { get; set; }
            
            [JsonPropertyName("api_key")]
            public string ApiKey { get; set; }
            
            [JsonPropertyName("api_secret_key")]
            public string ApiSecretKey { get; set; }
        }
    }
}
