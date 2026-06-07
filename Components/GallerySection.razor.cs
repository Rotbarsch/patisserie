using Microsoft.AspNetCore.Components;
using Patisserie.Models;
using System.Net.Http.Json;

namespace Patisserie.Components;

public partial class GallerySection : ComponentBase
{
    [Inject] private HttpClient Http { get; set; } = default!;

    protected List<GalleryItem>? Items { get; private set; }
    protected bool IsLoading { get; private set; } = true;

    protected string? ActiveCategory { get; set; } = null; // null = show all

    protected IReadOnlyList<string> Categories { get; private set; } = [];

    protected IEnumerable<GalleryItem> FilteredItems =>
        Items is null ? [] :
        ActiveCategory is null ? Items :
        Items.Where(i => i.Category == ActiveCategory);

    private const string DataPath = "data/gallery.json";

    protected override async Task OnInitializedAsync()
    {
        try
        {
            var data = await Http.GetFromJsonAsync<GalleryData>(DataPath);
            Items = data?.Items ?? [];
            Categories = (data?.Categories ?? [])
                .OrderBy(c => c.Order)
                .Select(c => c.Name)
                .ToList();
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Could not load gallery data from '{DataPath}': {ex.Message}");
            Items = [];
            Categories = [];
        }
        finally
        {
            IsLoading = false;
        }
    }
}
