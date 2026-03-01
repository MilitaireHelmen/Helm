using helm.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace helm.Components.Dialogs;

public partial class ImageGalleryDialog : ComponentBase
{
    [CascadingParameter]
    private IMudDialogInstance MudDialog { get; set; } = default!;

    [Parameter]
    public string Title { get; set; } = "Gallery";

    [Parameter]
    public IReadOnlyList<CollectibleImage> Images { get; set; } = [];

    [Parameter]
    public int StartIndex { get; set; }

    private int SelectedIndex { get; set; }

    protected override void OnInitialized()
    {
        SelectedIndex = StartIndex;
    }

    private void Close() => MudDialog.Close();
}
