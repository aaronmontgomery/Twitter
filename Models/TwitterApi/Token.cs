using System.Text.Json.Serialization;

namespace Models
{
    public partial class TwitterApi
    {
        public class Token
        {
            [JsonPropertyName("access_token")]
            public string AccessToken { get; set; }
            
            [JsonPropertyName("token_type")]
            public string TokenType { get; set; }
        }
    }
}
