using helm.Models;
using helm.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;

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
    private string? SearchText { get => _searchText; set { _searchText = value; ApplyFilters(); UpdateUrl(); } }

    private string? _selectedItemType;
    private string? SelectedItemType { get => _selectedItemType; set { _selectedItemType = value; ApplyFilters(); UpdateUrl(); } }

    private string? _selectedCountry;
    private string? SelectedCountry { get => _selectedCountry; set { _selectedCountry = value; ApplyFilters(); UpdateUrl(); } }

    protected override void OnInitialized()
    {
        AllItems = CollectibleService.GetAll();
        ItemTypes = CollectibleService.GetItemTypes();
        Countries = CollectibleService.GetCountries();
        
        LoadFiltersFromUrl();
        ApplyFilters();
    }

    private void LoadFiltersFromUrl()
    {
        var uri = Navigation.ToAbsoluteUri(Navigation.Uri);
        var queryParams = QueryHelpers.ParseQuery(uri.Query);

        if (queryParams.TryGetValue("search", out var searchValue))
            _searchText = searchValue.ToString();

        if (queryParams.TryGetValue("type", out var typeValue))
            _selectedItemType = typeValue.ToString();

        if (queryParams.TryGetValue("country", out var countryValue))
            _selectedCountry = countryValue.ToString();
    }

    private void UpdateUrl()
    {
        var queryParams = new Dictionary<string, string?>();
        
        if (!string.IsNullOrWhiteSpace(_searchText))
            queryParams["search"] = _searchText;
        
        if (!string.IsNullOrWhiteSpace(_selectedItemType))
            queryParams["type"] = _selectedItemType;
        
        if (!string.IsNullOrWhiteSpace(_selectedCountry))
            queryParams["country"] = _selectedCountry;

        var url = queryParams.Any() 
            ? QueryHelpers.AddQueryString("/", queryParams!) 
            : "/";
        
        Navigation.NavigateTo(url, replace: true);
    }

    private void ApplyFilters() => FilteredItems = AllItems
        .Where(c => string.IsNullOrWhiteSpace(SearchText) ||
                    c.Name.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                    c.Description.Contains(SearchText, StringComparison.OrdinalIgnoreCase))
        .Where(c => string.IsNullOrWhiteSpace(SelectedItemType) ||
                    c.ItemType.Equals(SelectedItemType, StringComparison.OrdinalIgnoreCase))
        .Where(c => string.IsNullOrWhiteSpace(SelectedCountry) ||
                    c.Country.Equals(SelectedCountry, StringComparison.OrdinalIgnoreCase))
        .OrderBy(c => c.Name)
        .ToList();

    private void ClearFilters()
    {
        (_searchText, _selectedItemType, _selectedCountry) = (null, null, null);
        ApplyFilters();
        UpdateUrl();
    }

    private void ToggleFilterDrawer() => FilterDrawerOpen = !FilterDrawerOpen;

    private void ViewItem(string id)
    {
        var returnUrl = Navigation.Uri.Replace(Navigation.BaseUri.TrimEnd('/'), "");
        Navigation.NavigateTo($"/collectible/{id}?returnUrl={Uri.EscapeDataString(returnUrl)}");
    }
}
