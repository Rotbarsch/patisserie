using System.Text.Json.Serialization;

namespace Patisserie.Models;

public class GalleryCategory
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("order")]
    public int Order { get; set; }
}
