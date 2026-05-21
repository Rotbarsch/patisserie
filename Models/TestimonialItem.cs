using System.Text.Json.Serialization;

namespace Patisserie.Models;

public class TestimonialItem
{
    [JsonPropertyName("quote")]
    public string Quote { get; set; } = string.Empty;

    [JsonPropertyName("author")]
    public string Author { get; set; } = string.Empty;
}
