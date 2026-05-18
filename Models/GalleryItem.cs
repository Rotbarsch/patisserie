using System.Text.Json.Serialization;

namespace Patisserie.Models;

public class GalleryItem
{
    [JsonPropertyName("imagePath")]
    public string ImagePath { get; set; } = string.Empty;

    [JsonPropertyName("alt")]
    public string Alt { get; set; } = string.Empty;

    [JsonPropertyName("title")]
    public string? Title { get; set; }
}
