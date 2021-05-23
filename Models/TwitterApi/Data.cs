namespace Models
{
    public partial class TwitterApi
    {
        public class Data
        {
            [System.Text.Json.Serialization.JsonPropertyName("id")]
            public string Id { get; set; }

            [System.Text.Json.Serialization.JsonPropertyName("text")]
            public string Text { get; set; }
        }
    }
}
