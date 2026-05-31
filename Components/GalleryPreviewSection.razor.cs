using Microsoft.AspNetCore.Components;
using Patisserie.Models;
using System.Net.Http.Json;

namespace Patisserie.Components;

public partial class GalleryPreviewSection : ComponentBase
{
    [Inject] private HttpClient Http { get; set; } = default!;

    protected List<GalleryItem>? Items { get; private set; }

    protected string ActiveCategory { get; set; } = "Hochzeitstorten";

    protected IReadOnlyList<string> Categories { get; } =
        ["Hochzeitstorten", "Motivtorten", "Macarons & Patisserie", "Kinder-Motivtorten"];

    protected IEnumerable<GalleryItem> FilteredItems =>
        Items?.Where(i => i.Category == ActiveCategory).Take(4)
        ?? Enumerable.Empty<GalleryItem>();

    protected override async Task OnInitializedAsync()
    {
        Items = await Http.GetFromJsonAsync<List<GalleryItem>>("data/gallery.json");
    }
}
