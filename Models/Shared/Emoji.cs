namespace Models
{
    public partial class Shared
    {
        public class Emoji
        {
            [System.Text.Json.Serialization.JsonPropertyName("unified")]
            public string Unified { get; set; }
            [System.Text.Json.Serialization.JsonPropertyName("name")]
            public string Name { get; set; }
            [System.Text.Json.Serialization.JsonPropertyName("image")]
            public string Image { get; set; }
            public char[] Unicode { get; set; }
        }
    }

}
