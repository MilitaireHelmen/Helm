using helm.Components.Dialogs;
using helm.Models;
using helm.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace helm.Components.Pages;

public partial class CollectibleDetail : ComponentBase
{
    [Parameter]
    public string Id { get; set; } = string.Empty;

    [Inject]
    private ICollectibleService CollectibleService { get; set; } = default!;

    [Inject]
    private IDialogService DialogService { get; set; } = default!;

    private Collectible? Item { get; set; }
    private int SelectedImageIndex { get; set; }

    private CollectibleImage? SelectedImage =>
        Item?.Images.ElementAtOrDefault(SelectedImageIndex) ?? Item?.Images.FirstOrDefault();

    protected override void OnParametersSet()
    {
        Item = CollectibleService.GetById(Id);
        SelectedImageIndex = 0;
    }

    private void SelectImage(int index)
    {
        SelectedImageIndex = index;
    }

    private async Task OpenGallery(int startIndex)
    {
        if (Item is null || Item.Images.Count == 0)
        {
            return;
        }

        var parameters = new DialogParameters<ImageGalleryDialog>
        {
            { x => x.Title, Item.Name },
            { x => x.Images, Item.Images },
            { x => x.StartIndex, startIndex }
        };

        var options = new DialogOptions
        {
            MaxWidth = MaxWidth.ExtraExtraLarge,
            FullWidth = true,
            CloseOnEscapeKey = true,
            BackdropClick = true,
            FullScreen = false,
            NoHeader = true
        };

        await DialogService.ShowAsync<ImageGalleryDialog>(null, parameters, options);
    }

    private string GetThumbnailClass(int index) =>
        index == SelectedImageIndex
            ? "pa-1 rounded border-2 border-solid mud-border-primary"
            : "pa-1 rounded";

    private string FormatDescription(string description)
    {
        if (string.IsNullOrWhiteSpace(description))
        {
            return string.Empty;
        }

        var text = description.Trim();
        text = System.Text.RegularExpressions.Regex.Replace(text, @"\r\n|\r|\n", "\n");
        text = System.Text.RegularExpressions.Regex.Replace(text, @"\n{2,}", "<!PARAGRAPH!>");
        text = System.Text.RegularExpressions.Regex.Replace(text, @"\n", " ");
        text = text.Replace("<!PARAGRAPH!>", "\n\n");
        
        return text;
    }
}
