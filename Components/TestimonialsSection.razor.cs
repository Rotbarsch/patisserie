using Microsoft.AspNetCore.Components;
using Patisserie.Models;
using System.Net.Http.Json;

namespace Patisserie.Components;

public partial class TestimonialsSection : ComponentBase
{
    [Inject] private HttpClient Http { get; set; } = default!;

    protected List<TestimonialItem>? Items { get; private set; }

    protected override async Task OnInitializedAsync()
    {
        Items = await Http.GetFromJsonAsync<List<TestimonialItem>>("data/testimonials.json");
    }
}
