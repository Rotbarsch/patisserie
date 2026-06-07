using System.Text.Json.Serialization;

namespace Patisserie.Models;

public class GalleryData
{
    [JsonPropertyName("categories")]
    public List<GalleryCategory> Categories { get; set; } = [];

    [JsonPropertyName("items")]
    public List<GalleryItem> Items { get; set; } = [];
}
