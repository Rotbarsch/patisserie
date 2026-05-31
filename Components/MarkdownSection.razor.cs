using Markdig;
using Microsoft.AspNetCore.Components;

namespace Patisserie.Components;

public partial class MarkdownSection : ComponentBase
{
    [Inject] private HttpClient Http { get; set; } = default!;

    /// <summary>Path relative to wwwroot, e.g. "content/ueber-mich.md"</summary>
    [Parameter, EditorRequired] public string File { get; set; } = default!;

    private string? _html;
    private string? _error;

    protected override async Task OnParametersSetAsync()
    {
        _html = null;
        _error = null;
        try
        {
            var markdown = await Http.GetStringAsync(File);
            _html = Markdown.ToHtml(markdown, new MarkdownPipelineBuilder().UseAdvancedExtensions().UseSmartyPants().Build());
        }
        catch (Exception ex)
        {
            _error = $"Inhalt konnte nicht geladen werden. ({ex.Message})";
        }
    }
}
