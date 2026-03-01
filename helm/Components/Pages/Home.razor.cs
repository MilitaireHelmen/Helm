using helm.Models;
using helm.Services;
using Microsoft.AspNetCore.Components;

namespace helm.Components.Pages;

public enum ViewMode { Large, Small, List }

public partial class Home : ComponentBase
{
    [Inject] private ICollectibleService CollectibleService { get; set; } = default!;
    [Inject] private NavigationManager Navigation { get; set; } = default!;

    private IReadOnlyList<Collectible> AllItems { get; set; } = [];
    private IReadOnlyList<string> ItemTypes { get; set; } = [];
    private IReadOnlyList<string> Countries { get; set; } = [];
    private List<Collectible> FilteredItems { get; set; } = [];

    private bool FilterDrawerOpen { get; set; }
    private ViewMode CurrentViewMode { get; set; } = ViewMode.Large;

    private bool HasActiveFilters =>
        !string.IsNullOrWhiteSpace(SearchText) ||
        !string.IsNullOrWhiteSpace(SelectedItemType) ||
        !string.IsNullOrWhiteSpace(SelectedCountry);

    private string? _searchText;
    private string? SearchText { get => _searchText; set { _searchText = value; ApplyFilters(); } }

    private string? _selectedItemType;
    private string? SelectedItemType { get => _selectedItemType; set { _selectedItemType = value; ApplyFilters(); } }

    private string? _selectedCountry;
    private string? SelectedCountry { get => _selectedCountry; set { _selectedCountry = value; ApplyFilters(); } }

    protected override void OnInitialized()
    {
        AllItems = CollectibleService.GetAll();
        ItemTypes = CollectibleService.GetItemTypes();
        Countries = CollectibleService.GetCountries();
        ApplyFilters();
    }

    private void ApplyFilters() => FilteredItems = AllItems
        .Where(c => string.IsNullOrWhiteSpace(SearchText) ||
                    c.Name.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                    c.Description.Contains(SearchText, StringComparison.OrdinalIgnoreCase))
        .Where(c => string.IsNullOrWhiteSpace(SelectedItemType) ||
                    c.ItemType.Equals(SelectedItemType, StringComparison.OrdinalIgnoreCase))
        .Where(c => string.IsNullOrWhiteSpace(SelectedCountry) ||
                    c.Country.Equals(SelectedCountry, StringComparison.OrdinalIgnoreCase))
        .ToList();

    private void ClearFilters()
    {
        (_searchText, _selectedItemType, _selectedCountry) = (null, null, null);
        ApplyFilters();
    }

    private void ToggleFilterDrawer() => FilterDrawerOpen = !FilterDrawerOpen;

    private void ViewItem(string id) => Navigation.NavigateTo($"/collectible/{id}");
}
