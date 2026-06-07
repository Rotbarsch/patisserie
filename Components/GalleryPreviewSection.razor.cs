using Microsoft.AspNetCore.Components;
using Patisserie.Models;
using System.Net.Http.Json;

namespace Patisserie.Components;

public partial class GalleryPreviewSection : ComponentBase
{
    [Inject] private HttpClient Http { get; set; } = default!;

    protected List<GalleryItem>? Items { get; private set; }

    protected string ActiveCategory { get; set; } = string.Empty;

    protected IReadOnlyList<string> Categories { get; private set; } = [];

    protected IEnumerable<GalleryItem> FilteredItems =>
        Items?.Where(i => i.Category == ActiveCategory).Take(4)
        ?? Enumerable.Empty<GalleryItem>();

    protected override async Task OnInitializedAsync()
    {
        var data = await Http.GetFromJsonAsync<GalleryData>("data/gallery.json");
        Items = data?.Items ?? [];
        Categories = (data?.Categories ?? [])
            .OrderBy(c => c.Order)
            .Select(c => c.Name)
            .ToList();
        ActiveCategory = Categories.FirstOrDefault() ?? string.Empty;
    }
}
