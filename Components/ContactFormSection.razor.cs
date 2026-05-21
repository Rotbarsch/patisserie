using Microsoft.AspNetCore.Components;

namespace Patisserie.Components;

public partial class ContactFormSection : ComponentBase
{
    [Parameter] public string Title { get; set; } = "Anfrage senden";
    [Parameter] public string Subtitle { get; set; } =
        "Erzähl mir von deiner Traumtorte – ich melde mich innerhalb von 48 Stunden.";
}
