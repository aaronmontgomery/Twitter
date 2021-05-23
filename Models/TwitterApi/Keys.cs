namespace Models
{
    public partial class TwitterApi
    {
        public class Keys
        {
            [System.Text.Json.Serialization.JsonPropertyName("name")]
            public string Name { get; set; }

            [System.Text.Json.Serialization.JsonPropertyName("api_key")]
            public string ApiKey { get; set; }

            [System.Text.Json.Serialization.JsonPropertyName("api_secret_key")]
            public string ApiSecretKey { get; set; }
        }
    }
}
