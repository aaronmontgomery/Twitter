namespace Models
{
    public partial class TwitterApi
    {
        public class Tweet
        {
            [System.Text.Json.Serialization.JsonPropertyName("data")]
            public Data Data { get; set; }
        }
    }
}
